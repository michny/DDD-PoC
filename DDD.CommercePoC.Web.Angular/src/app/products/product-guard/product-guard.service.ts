import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import validator = require('validator');

@Injectable()
export class ProductGuardService implements CanActivate {

  constructor(private readonly _router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let id = route.url[1].path;
    if (!validator.isUUID(id)) {
      alert('Invalid product Id'); //Could route to error page instead
      this._router.navigate(['/products']);
      return false;
    };
    return true;
  }

  

}
