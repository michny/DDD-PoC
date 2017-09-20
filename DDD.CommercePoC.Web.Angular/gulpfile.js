var gulp = require("gulp"),
    run = require("gulp-run"),
    watch = require("gulp-watch");

gulp.task("default",
  function() {
    console.log("Hi! I'm Gulp's Default task!");
  });

gulp.task("copy",
  function() {
    return run("npm run dist").exec();
  });

gulp.task("watch", function() {
  return watch(["**/*.ts", "**/*.css", "**/*.html"], function() {
    console.log("Hello");
    return run("npm run dist").exec();
  });
});
