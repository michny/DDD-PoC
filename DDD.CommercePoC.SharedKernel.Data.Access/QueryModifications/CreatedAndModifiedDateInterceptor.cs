using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;

namespace DDD.CommercePoC.SharedKernel.Data.Access.QueryModifications
{
    public class CreatedAndModifiedDateInterceptor : IDbCommandTreeInterceptor
    {
        private const string CreatedColumnName = "Created";
        private const string ModifiedColumnName = "LastModified";

        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace != DataSpace.SSpace)
            {
                return;
            }

            var insertCommand = interceptionContext.Result as DbInsertCommandTree;
            if (insertCommand != null)
            {
                interceptionContext.Result = HandleInsertCommand(insertCommand);
            }

            var updateCommand = interceptionContext.OriginalResult as DbUpdateCommandTree;
            if (updateCommand != null)
            {
                interceptionContext.Result = HandleUpdateCommand(updateCommand);
            }
        }

        private static DbCommandTree HandleInsertCommand(DbInsertCommandTree insertCommand)
        {
            var now = DateTime.UtcNow;

            var setClauses = insertCommand.SetClauses
                .Select(clause => clause.UpdateIfMatch(CreatedColumnName, DbExpression.FromDateTime(now)))
                .Select(clause => clause.UpdateIfMatch(ModifiedColumnName, DbExpression.FromDateTime(now)))
                .ToList();

            return new DbInsertCommandTree(
                insertCommand.MetadataWorkspace,
                insertCommand.DataSpace,
                insertCommand.Target,
                setClauses.AsReadOnly(),
                insertCommand.Returning);
        }

        private static DbCommandTree HandleUpdateCommand(DbUpdateCommandTree updateCommand)
        {
            var now = DateTime.UtcNow;

            var setClauses = updateCommand.SetClauses
                .Select(clause => clause.UpdateIfMatch(ModifiedColumnName, DbExpression.FromDateTime(now)))
                .ToList();

            //Removing Created column as it should never be allowed to be modified
            setClauses.RemoveAll(clause => clause.IsFor(CreatedColumnName));

            return new DbUpdateCommandTree(
                updateCommand.MetadataWorkspace,
                updateCommand.DataSpace,
                updateCommand.Target,
                updateCommand.Predicate,
                setClauses.AsReadOnly(), null);
        }
    }
}