webpackJsonp(["main"],{

/***/ "../../../../../src/$$_gendir lazy recursive":
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncatched exception popping up in devtools
	return Promise.resolve().then(function() {
		throw new Error("Cannot find module '" + req + "'.");
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "../../../../../src/$$_gendir lazy recursive";

/***/ }),

/***/ "../../../../../src/app/admin/admin-index/admin-index.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/admin/admin-index/admin-index.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  admin-index works!\n</p>\n"

/***/ }),

/***/ "../../../../../src/app/admin/admin-index/admin-index.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var AdminIndexComponent = (function () {
    function AdminIndexComponent() {
    }
    AdminIndexComponent.prototype.ngOnInit = function () {
    };
    return AdminIndexComponent;
}());
AdminIndexComponent = __decorate([
    core_1.Component({
        selector: 'app-admin-index',
        template: __webpack_require__("../../../../../src/app/admin/admin-index/admin-index.component.html"),
        styles: [__webpack_require__("../../../../../src/app/admin/admin-index/admin-index.component.css")]
    }),
    __metadata("design:paramtypes", [])
], AdminIndexComponent);
exports.AdminIndexComponent = AdminIndexComponent;
//# sourceMappingURL=admin-index.component.js.map

/***/ }),

/***/ "../../../../../src/app/admin/admin-products/admin-products.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/admin/admin-products/admin-products.component.html":
/***/ (function(module, exports) {

module.exports = "<p>\n  admin-products works!\n</p>\n"

/***/ }),

/***/ "../../../../../src/app/admin/admin-products/admin-products.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var AdminProductsComponent = (function () {
    function AdminProductsComponent() {
    }
    AdminProductsComponent.prototype.ngOnInit = function () {
    };
    return AdminProductsComponent;
}());
AdminProductsComponent = __decorate([
    core_1.Component({
        selector: 'app-admin-products',
        template: __webpack_require__("../../../../../src/app/admin/admin-products/admin-products.component.html"),
        styles: [__webpack_require__("../../../../../src/app/admin/admin-products/admin-products.component.css")]
    }),
    __metadata("design:paramtypes", [])
], AdminProductsComponent);
exports.AdminProductsComponent = AdminProductsComponent;
//# sourceMappingURL=admin-products.component.js.map

/***/ }),

/***/ "../../../../../src/app/admin/admin-routing.module.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var router_1 = __webpack_require__("../../../router/@angular/router.es5.js");
var admin_index_component_1 = __webpack_require__("../../../../../src/app/admin/admin-index/admin-index.component.ts");
var admin_products_component_1 = __webpack_require__("../../../../../src/app/admin/admin-products/admin-products.component.ts");
var routes = [
    { path: 'admin/index', component: admin_index_component_1.AdminIndexComponent },
    { path: 'admin/products', component: admin_products_component_1.AdminProductsComponent }
];
var AdminRoutingModule = (function () {
    function AdminRoutingModule() {
    }
    return AdminRoutingModule;
}());
AdminRoutingModule = __decorate([
    core_1.NgModule({
        imports: [router_1.RouterModule.forChild(routes)],
        exports: [router_1.RouterModule]
    })
], AdminRoutingModule);
exports.AdminRoutingModule = AdminRoutingModule;
//# sourceMappingURL=admin-routing.module.js.map

/***/ }),

/***/ "../../../../../src/app/admin/admin.module.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var common_1 = __webpack_require__("../../../common/@angular/common.es5.js");
var forms_1 = __webpack_require__("../../../forms/@angular/forms.es5.js");
var admin_routing_module_1 = __webpack_require__("../../../../../src/app/admin/admin-routing.module.ts");
var admin_index_component_1 = __webpack_require__("../../../../../src/app/admin/admin-index/admin-index.component.ts");
var admin_products_component_1 = __webpack_require__("../../../../../src/app/admin/admin-products/admin-products.component.ts");
var AdminModule = (function () {
    function AdminModule() {
    }
    return AdminModule;
}());
AdminModule = __decorate([
    core_1.NgModule({
        imports: [
            common_1.CommonModule,
            forms_1.FormsModule,
            admin_routing_module_1.AdminRoutingModule
        ],
        declarations: [admin_index_component_1.AdminIndexComponent, admin_products_component_1.AdminProductsComponent]
    })
], AdminModule);
exports.AdminModule = AdminModule;
//# sourceMappingURL=admin.module.js.map

/***/ }),

/***/ "../../../../../src/app/app-routing.module.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var router_1 = __webpack_require__("../../../router/@angular/router.es5.js");
var index_component_1 = __webpack_require__("../../../../../src/app/index/index.component.ts");
var routes = [
    { path: 'index', component: index_component_1.IndexComponent },
    { path: '', redirectTo: 'index', pathMatch: 'full' }
];
var AppRoutingModule = (function () {
    function AppRoutingModule() {
    }
    return AppRoutingModule;
}());
AppRoutingModule = __decorate([
    core_1.NgModule({
        imports: [router_1.RouterModule.forRoot(routes, { useHash: true })],
        exports: [router_1.RouterModule]
    })
], AppRoutingModule);
exports.AppRoutingModule = AppRoutingModule;
//# sourceMappingURL=app-routing.module.js.map

/***/ }),

/***/ "../../../../../src/app/app.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/app.component.html":
/***/ (function(module, exports) {

module.exports = "<!--The content below is only a placeholder and can be replaced.-->\n<div style=\"text-align:center\">\n  <h1>\n    {{title}}\n  </h1>\n</div>\n<div>\n  <app-cart-icon></app-cart-icon>\n  <router-outlet></router-outlet>\n  <app-cart-icon></app-cart-icon>\n</div>\n\n"

/***/ }),

/***/ "../../../../../src/app/app.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var AppComponent = (function () {
    function AppComponent() {
        this.title = 'Commerce PoC';
        this.newProperty = 'Hello!!!';
    }
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'app-root',
        template: __webpack_require__("../../../../../src/app/app.component.html"),
        styles: [__webpack_require__("../../../../../src/app/app.component.css")]
    })
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map

/***/ }),

/***/ "../../../../../src/app/app.module.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = __webpack_require__("../../../platform-browser/@angular/platform-browser.es5.js");
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var http_1 = __webpack_require__("../../../common/@angular/common/http.es5.js");
var forms_1 = __webpack_require__("../../../forms/@angular/forms.es5.js");
var app_component_1 = __webpack_require__("../../../../../src/app/app.component.ts");
var products_module_1 = __webpack_require__("../../../../../src/app/products/products.module.ts");
var app_routing_module_1 = __webpack_require__("../../../../../src/app/app-routing.module.ts");
var index_component_1 = __webpack_require__("../../../../../src/app/index/index.component.ts");
var cart_module_1 = __webpack_require__("../../../../../src/app/cart/cart.module.ts");
var admin_module_1 = __webpack_require__("../../../../../src/app/admin/admin.module.ts");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        declarations: [
            app_component_1.AppComponent,
            index_component_1.IndexComponent
        ],
        imports: [
            platform_browser_1.BrowserModule,
            http_1.HttpClientModule,
            forms_1.FormsModule,
            products_module_1.ProductsModule,
            cart_module_1.CartModule,
            admin_module_1.AdminModule,
            app_routing_module_1.AppRoutingModule
        ],
        providers: [],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map

/***/ }),

/***/ "../../../../../src/app/cart/cart-icon/cart-icon.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".cart-link {\r\n  float: right;\r\n  padding: 10px;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/cart/cart-icon/cart-icon.component.html":
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <a [routerLink]=\"['/cart']\" class=\"cart-link\">\r\n    <span class=\"glyphicon glyphicon-shopping-cart\"></span>\r\n    <span>{{contentCount}}</span>\r\n    Your Cart\r\n    <span>{{contentPrice}}</span>\r\n  </a>\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../src/app/cart/cart-icon/cart-icon.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var Cartservice = __webpack_require__("../../../../../src/app/cart/cart-service/cart.service.ts");
var CartService = Cartservice.CartService;
var CartIconComponent = (function () {
    function CartIconComponent(_cartService) {
        this._cartService = _cartService;
    }
    CartIconComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.updateContentCount();
        //Subscribing to the cartLineItemUpdated event and then retrieving the cart again to get number of items in it
        this._cartService.cartLineItemUpdated.subscribe(function (value) {
            console.log("Received " + JSON.stringify(value) + " from cartService event.");
            _this.updateContentCount();
        });
    };
    CartIconComponent.prototype.updateContentCount = function () {
        var _this = this;
        this._cartService.getCart().subscribe(function (cart) {
            //Equivalent to "cart.CartLineItems.Select(l => l.count).Sum(c => c); in C#"
            _this.contentCount = cart.cartLineItems.map(function (l) { return l.count; }).reduce(function (a, b) { return a + b; }, 0);
            _this.contentPrice = cart.priceFormatted;
        });
    };
    return CartIconComponent;
}());
CartIconComponent = __decorate([
    core_1.Component({
        selector: 'app-cart-icon',
        template: __webpack_require__("../../../../../src/app/cart/cart-icon/cart-icon.component.html"),
        styles: [__webpack_require__("../../../../../src/app/cart/cart-icon/cart-icon.component.css")]
    }),
    __metadata("design:paramtypes", [typeof (_a = typeof CartService !== "undefined" && CartService) === "function" && _a || Object])
], CartIconComponent);
exports.CartIconComponent = CartIconComponent;
var _a;
//# sourceMappingURL=cart-icon.component.js.map

/***/ }),

/***/ "../../../../../src/app/cart/cart-routing.module.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var router_1 = __webpack_require__("../../../router/@angular/router.es5.js");
var cart_component_1 = __webpack_require__("../../../../../src/app/cart/cart/cart.component.ts");
var routes = [
    { path: 'cart', component: cart_component_1.CartComponent }
];
var CartRoutingModule = (function () {
    function CartRoutingModule() {
    }
    return CartRoutingModule;
}());
CartRoutingModule = __decorate([
    core_1.NgModule({
        imports: [router_1.RouterModule.forChild(routes)],
        exports: [router_1.RouterModule]
    })
], CartRoutingModule);
exports.CartRoutingModule = CartRoutingModule;
//# sourceMappingURL=cart-routing.module.js.map

/***/ }),

/***/ "../../../../../src/app/cart/cart-service/cart.service.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var http_1 = __webpack_require__("../../../common/@angular/common/http.es5.js");
var Observable_1 = __webpack_require__("../../../../rxjs/Observable.js");
__webpack_require__("../../../../rxjs/add/observable/throw.js");
__webpack_require__("../../../../rxjs/add/operator/catch.js");
__webpack_require__("../../../../rxjs/add/operator/do.js");
var CartService = (function () {
    function CartService(_httpClient) {
        this._httpClient = _httpClient;
        this._url = '/api/cart';
        this.cartLineItemUpdated = new core_1.EventEmitter();
    }
    CartService.prototype.addToCart = function (variantId) {
        var _this = this;
        console.log("Adding variant with id " + variantId + " to cart...");
        return this._httpClient.post(this._url + '/' + variantId, {}, {})
            .do(function (data) {
            console.log("Result from service: " + JSON.stringify(data));
            _this.cartLineItemUpdated.emit(data);
        })
            .catch(this.handleError);
    };
    ;
    CartService.prototype.removeFromCart = function (variantId) {
        var _this = this;
        console.log("Removing variant with id " + variantId + " to cart...");
        return this._httpClient.delete(this._url + '/' + variantId)
            .do(function (data) {
            console.log("Result from service: " + JSON.stringify(data));
            _this.cartLineItemUpdated.emit(data);
        })
            .catch(this.handleError);
    };
    CartService.prototype.getCart = function () {
        console.log('Getting current cart');
        return this._httpClient.get(this._url)
            .do(function (data) { return console.log("Received cart " + JSON.stringify(data)); })
            .catch(this.handleError);
    };
    CartService.prototype.handleError = function (err) {
        //TODO Perhaps log to a logging service or something
        console.log(err.message);
        return Observable_1.Observable.throw(err.message); //throwing error to calling code
    };
    ;
    return CartService;
}());
__decorate([
    core_1.Output(),
    __metadata("design:type", Object)
], CartService.prototype, "cartLineItemUpdated", void 0);
CartService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [typeof (_a = typeof http_1.HttpClient !== "undefined" && http_1.HttpClient) === "function" && _a || Object])
], CartService);
exports.CartService = CartService;
var _a;
//# sourceMappingURL=cart.service.js.map

/***/ }),

/***/ "../../../../../src/app/cart/cart.module.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var common_1 = __webpack_require__("../../../common/@angular/common.es5.js");
var cart_routing_module_1 = __webpack_require__("../../../../../src/app/cart/cart-routing.module.ts");
var cart_service_1 = __webpack_require__("../../../../../src/app/cart/cart-service/cart.service.ts");
var cart_component_1 = __webpack_require__("../../../../../src/app/cart/cart/cart.component.ts");
var cart_icon_component_1 = __webpack_require__("../../../../../src/app/cart/cart-icon/cart-icon.component.ts");
var CartModule = (function () {
    function CartModule() {
    }
    return CartModule;
}());
CartModule = __decorate([
    core_1.NgModule({
        imports: [
            common_1.CommonModule,
            cart_routing_module_1.CartRoutingModule
        ],
        declarations: [cart_component_1.CartComponent, cart_icon_component_1.CartIconComponent],
        exports: [cart_icon_component_1.CartIconComponent],
        providers: [cart_service_1.CartService]
    })
], CartModule);
exports.CartModule = CartModule;
//# sourceMappingURL=cart.module.js.map

/***/ }),

/***/ "../../../../../src/app/cart/cart/cart.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".cart-total-row {\r\n  font-weight: bold\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/cart/cart/cart.component.html":
/***/ (function(module, exports) {

module.exports = "<div>\r\n  <h2>Your current shopping cart!</h2>\r\n\r\n  <div class=\"table-responsive\">\r\n    <table class=\"table table-striped\" *ngIf=\"cart && cart.cartLineItems && cart.cartLineItems.length > 0\">\r\n      <thead>\r\n      <tr>\r\n        <th>Variant</th>\r\n        <th>Quantity</th>\r\n        <th>Price</th>\r\n      </tr>\r\n      </thead>\r\n      <tbody>\r\n      <tr *ngFor=\"let cartLineItem of cart.cartLineItems\">\r\n        <td>{{cartLineItem.variantName}}</td>\r\n        <td>\r\n          <span class=\"glyphicon glyphicon-minus\" (click)=\"removeVariant(cartLineItem.variantId);\"></span>\r\n          {{cartLineItem.count}}\r\n          <span class=\"glyphicon glyphicon-plus\" (click)=\"addVariant(cartLineItem.variantId);\"></span>\r\n        </td>\r\n        <td>{{cartLineItem.priceFormatted}}</td>\r\n        <td></td>\r\n      </tr>\r\n      <tr class=\"cart-total-row\">\r\n        <td>Total</td>\r\n        <td>{{cart.cartContentCount}}</td>\r\n        <td>{{cart.priceFormatted}}</td>\r\n      </tr>\r\n      </tbody>\r\n    </table>\r\n\r\n    <p *ngIf=\"!cart || !cart.cartLineItems || cart.cartLineItems.length === 0\">\r\n      You're shopping cart is empty! Go <a [routerLink]=\"['/products']\">here</a> to find some products!\r\n    </p>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../src/app/cart/cart/cart.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var Cartservice = __webpack_require__("../../../../../src/app/cart/cart-service/cart.service.ts");
var CartService = Cartservice.CartService;
var CartComponent = (function () {
    function CartComponent(_cartService) {
        this._cartService = _cartService;
    }
    CartComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._cartService.getCart()
            .subscribe(function (data) {
            _this.cart = data;
            _this.cartContentCount = data.cartLineItems.map(function (cli) { return cli.count; }).reduce(function (a, b) { return a + b; }, 0);
        });
    };
    CartComponent.prototype.removeVariant = function (variantId) {
        var _this = this;
        this._cartService.removeFromCart(variantId)
            .subscribe(function (data) {
            console.log("Removed Variant: " + JSON.stringify(data));
            _this.ngOnInit();
        });
    };
    CartComponent.prototype.addVariant = function (variantId) {
        var _this = this;
        this._cartService.addToCart(variantId)
            .subscribe(function (data) {
            console.log("Added Variant: " + JSON.stringify(data));
            _this.ngOnInit();
        });
    };
    return CartComponent;
}());
CartComponent = __decorate([
    core_1.Component({
        selector: 'app-cart',
        template: __webpack_require__("../../../../../src/app/cart/cart/cart.component.html"),
        styles: [__webpack_require__("../../../../../src/app/cart/cart/cart.component.css")]
    }),
    __metadata("design:paramtypes", [typeof (_a = typeof CartService !== "undefined" && CartService) === "function" && _a || Object])
], CartComponent);
exports.CartComponent = CartComponent;
var _a;
//# sourceMappingURL=cart.component.js.map

/***/ }),

/***/ "../../../../../src/app/index/index.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/index/index.component.html":
/***/ (function(module, exports) {

module.exports = "<p>Hello and welcome!</p>\n<p>I would like to welcome you to our humble website! </p>\n<p>Click <a [routerLink]=\"['/products']\">here</a> to see our products!</p>\n"

/***/ }),

/***/ "../../../../../src/app/index/index.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var IndexComponent = (function () {
    function IndexComponent() {
    }
    IndexComponent.prototype.ngOnInit = function () {
    };
    return IndexComponent;
}());
IndexComponent = __decorate([
    core_1.Component({
        selector: 'app-index',
        template: __webpack_require__("../../../../../src/app/index/index.component.html"),
        styles: [__webpack_require__("../../../../../src/app/index/index.component.css")]
    }),
    __metadata("design:paramtypes", [])
], IndexComponent);
exports.IndexComponent = IndexComponent;
//# sourceMappingURL=index.component.js.map

/***/ }),

/***/ "../../../../../src/app/products/product-details/product-details.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".product-details-id-header {\r\n  font-style: italic;\r\n  font-size: 75%;\r\n  color: #696969\r\n}\r\n\r\n.btn-add-to-cart {\r\n  margin: 10px;\r\n  vertical-align: central\r\n}\r\n\r\n.image-full {\r\n\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/products/product-details/product-details.component.html":
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"product\">\r\n  <div class=\"row\">\r\n    <h1>{{product.name}}</h1>\r\n    <p class=\"product-details-id-header\">{{product.id}}</p>\r\n  </div>\r\n  <br/>\r\n  <div class=\"row\">\r\n    <div>\r\n      <select *ngIf=\"product.variants && product.variants.length\" [(ngModel)]=\"selectedVariant\">\r\n        <option *ngFor=\"let variant of product.variants\" [ngValue]=\"variant\">{{variant.name}}</option>\r\n      </select>\r\n      <span>Price: {{selectedVariant.priceFormatted}}</span>\r\n      <button class=\"btn btn-warning glyphicon glyphicon-shopping-cart btn-add-to-cart\" (click)=\"addToCart()\">Add to cart</button>\r\n    </div>\r\n\r\n    <div class=\"table-responsive col-md-4\">\r\n      <table class=\"table table-hover\">\r\n        <tbody>\r\n        <tr>\r\n          <td>Name</td>\r\n          <td>{{product.name}}</td>\r\n        </tr>\r\n        <tr>\r\n          <td>Id</td>\r\n          <td>{{product.id}}</td>\r\n        </tr>\r\n        </tbody>\r\n      </table>\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n      <img class=\"image-full\" [src]=\"selectedVariant.imageUrl\"/>\r\n    </div>\r\n  </div>\r\n  <div class=\"row\">\r\n    <a class=\"btn btn-default\" [routerLink]=\"['/products']\">Back to products</a>\r\n  </div>\r\n</div>\r\n\r\n"

/***/ }),

/***/ "../../../../../src/app/products/product-details/product-details.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var router_1 = __webpack_require__("../../../router/@angular/router.es5.js");
var Productsservice = __webpack_require__("../../../../../src/app/products/productsservice/products.service.ts");
var ProductsService = Productsservice.ProductsService;
var Cartservice = __webpack_require__("../../../../../src/app/cart/cart-service/cart.service.ts");
var CartService = Cartservice.CartService;
var ProductDetailsComponent = (function () {
    function ProductDetailsComponent(_route, _router, _productsService, _cartService) {
        this._route = _route;
        this._router = _router;
        this._productsService = _productsService;
        this._cartService = _cartService;
    }
    ProductDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        var id = this._route.snapshot.paramMap.get('id');
        this._productsService.getProduct(id)
            .subscribe(function (product) {
            _this.product = product;
            _this.selectedVariant = product.variants[0];
        }, function (error) { return _this.errorMessage = error; });
    };
    ProductDetailsComponent.prototype.addToCart = function () {
        this._cartService.addToCart(this.selectedVariant.id)
            .subscribe(function (data) {
            console.log("Received cart lineitem " + JSON.stringify(data) + " from cartService in product-details.");
        });
    };
    return ProductDetailsComponent;
}());
ProductDetailsComponent = __decorate([
    core_1.Component({
        selector: 'app-product-details',
        template: __webpack_require__("../../../../../src/app/products/product-details/product-details.component.html"),
        styles: [__webpack_require__("../../../../../src/app/products/product-details/product-details.component.css")]
    }),
    __metadata("design:paramtypes", [typeof (_a = typeof router_1.ActivatedRoute !== "undefined" && router_1.ActivatedRoute) === "function" && _a || Object, typeof (_b = typeof router_1.Router !== "undefined" && router_1.Router) === "function" && _b || Object, typeof (_c = typeof ProductsService !== "undefined" && ProductsService) === "function" && _c || Object, typeof (_d = typeof CartService !== "undefined" && CartService) === "function" && _d || Object])
], ProductDetailsComponent);
exports.ProductDetailsComponent = ProductDetailsComponent;
var _a, _b, _c, _d;
//# sourceMappingURL=product-details.component.js.map

/***/ }),

/***/ "../../../../../src/app/products/product-guard/product-guard.service.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var router_1 = __webpack_require__("../../../router/@angular/router.es5.js");
var validator = __webpack_require__("../../../../validator/index.js");
var ProductGuardService = (function () {
    function ProductGuardService(_router) {
        this._router = _router;
    }
    ProductGuardService.prototype.canActivate = function (route, state) {
        var id = route.url[1].path;
        if (!validator.isUUID(id)) {
            alert('Invalid product Id'); //Could route to error page instead
            this._router.navigate(['/products']);
            return false;
        }
        ;
        return true;
    };
    return ProductGuardService;
}());
ProductGuardService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [typeof (_a = typeof router_1.Router !== "undefined" && router_1.Router) === "function" && _a || Object])
], ProductGuardService);
exports.ProductGuardService = ProductGuardService;
var _a;
//# sourceMappingURL=product-guard.service.js.map

/***/ }),

/***/ "../../../../../src/app/products/product-list/product-list.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".image-preview {\r\n  height: 30px;\r\n}\r\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/products/product-list/product-list.component.html":
/***/ (function(module, exports) {

module.exports = "<h1>All products</h1>\n\n<div class=\"table-responsive\">\n  <table class=\"table table-striped\" *ngIf=\"allProducts && allProducts.length\">\n    <thead>\n      <tr>\r\n        <th></th>\r\n        <th>Id</th>\r\n        <th>Name</th>\r\n        <th>First variant price</th>\r\n      </tr>\n    </thead>\n    <tbody>\n    <tr *ngFor=\"let product of filteredProducts\">\n      <td><img class=\"image-preview\" [src]=\"product.variants[0].imageUrl\" /></td>\n      <td><a [routerLink]=\"['/products/', product.id]\">{{product.id}}</a></td>\n      <td>{{product.name}}</td>\n      <td>{{product.variants[0].priceFormatted}}</td>\n    </tr>\n    </tbody>\n  </table>\n</div>\n"

/***/ }),

/***/ "../../../../../src/app/products/product-list/product-list.component.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var products_service_1 = __webpack_require__("../../../../../src/app/products/productsservice/products.service.ts");
var ProductListComponent = (function () {
    function ProductListComponent(_productsService) {
        this._productsService = _productsService;
    }
    ProductListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._productsService.getProducts()
            .subscribe(function (products) {
            _this.allProducts = products;
            _this.filteredProducts = _this.allProducts;
        }, function (error) { return console.log(error); }); //TODO This should be logged properly instead and shown to user. Should also generalize error handling for service calls
    };
    return ProductListComponent;
}());
ProductListComponent = __decorate([
    core_1.Component({
        selector: 'app-product-list',
        template: __webpack_require__("../../../../../src/app/products/product-list/product-list.component.html"),
        styles: [__webpack_require__("../../../../../src/app/products/product-list/product-list.component.css")]
    }),
    __metadata("design:paramtypes", [typeof (_a = typeof products_service_1.ProductsService !== "undefined" && products_service_1.ProductsService) === "function" && _a || Object])
], ProductListComponent);
exports.ProductListComponent = ProductListComponent;
var _a;
//# sourceMappingURL=product-list.component.js.map

/***/ }),

/***/ "../../../../../src/app/products/products-routing.module.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var router_1 = __webpack_require__("../../../router/@angular/router.es5.js");
var product_list_component_1 = __webpack_require__("../../../../../src/app/products/product-list/product-list.component.ts");
var product_details_component_1 = __webpack_require__("../../../../../src/app/products/product-details/product-details.component.ts");
var product_guard_service_1 = __webpack_require__("../../../../../src/app/products/product-guard/product-guard.service.ts");
var routes = [
    { path: 'products', component: product_list_component_1.ProductListComponent },
    { path: 'products/:id', canActivate: [product_guard_service_1.ProductGuardService], component: product_details_component_1.ProductDetailsComponent }
];
var ProductsRoutingModule = (function () {
    function ProductsRoutingModule() {
    }
    return ProductsRoutingModule;
}());
ProductsRoutingModule = __decorate([
    core_1.NgModule({
        imports: [router_1.RouterModule.forChild(routes)],
        exports: [router_1.RouterModule]
    })
], ProductsRoutingModule);
exports.ProductsRoutingModule = ProductsRoutingModule;
//# sourceMappingURL=products-routing.module.js.map

/***/ }),

/***/ "../../../../../src/app/products/products.module.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var common_1 = __webpack_require__("../../../common/@angular/common.es5.js");
var forms_1 = __webpack_require__("../../../forms/@angular/forms.es5.js");
var product_list_component_1 = __webpack_require__("../../../../../src/app/products/product-list/product-list.component.ts");
var product_details_component_1 = __webpack_require__("../../../../../src/app/products/product-details/product-details.component.ts");
var products_service_1 = __webpack_require__("../../../../../src/app/products/productsservice/products.service.ts");
var products_routing_module_1 = __webpack_require__("../../../../../src/app/products/products-routing.module.ts");
var product_guard_service_1 = __webpack_require__("../../../../../src/app/products/product-guard/product-guard.service.ts");
var cart_module_1 = __webpack_require__("../../../../../src/app/cart/cart.module.ts");
var ProductsModule = (function () {
    function ProductsModule() {
    }
    return ProductsModule;
}());
ProductsModule = __decorate([
    core_1.NgModule({
        imports: [
            common_1.CommonModule,
            forms_1.FormsModule,
            products_routing_module_1.ProductsRoutingModule,
            cart_module_1.CartModule
        ],
        declarations: [
            product_list_component_1.ProductListComponent,
            product_details_component_1.ProductDetailsComponent
        ],
        exports: [
            product_list_component_1.ProductListComponent,
            product_details_component_1.ProductDetailsComponent
        ],
        providers: [products_service_1.ProductsService, product_guard_service_1.ProductGuardService]
    })
], ProductsModule);
exports.ProductsModule = ProductsModule;
//# sourceMappingURL=products.module.js.map

/***/ }),

/***/ "../../../../../src/app/products/productsservice/products.service.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var http_1 = __webpack_require__("../../../common/@angular/common/http.es5.js");
var Observable_1 = __webpack_require__("../../../../rxjs/Observable.js");
__webpack_require__("../../../../rxjs/add/observable/throw.js");
__webpack_require__("../../../../rxjs/add/operator/catch.js");
__webpack_require__("../../../../rxjs/add/operator/do.js");
var ProductsService = (function () {
    function ProductsService(_httpClient) {
        this._httpClient = _httpClient;
        this._productUrl = '/api/products';
    }
    ProductsService.prototype.getProducts = function () {
        return this._httpClient.get(this._productUrl)
            .do(function (data) { return console.log("All: " + JSON.stringify(data)); })
            .catch(this.handleError);
    };
    ;
    ProductsService.prototype.getProduct = function (id) {
        return this._httpClient.get(this._productUrl + "/" + id)
            .do(function (data) { return console.log("Single product: " + JSON.stringify(data)); })
            .catch(this.handleError);
    };
    ;
    ProductsService.prototype.handleError = function (err) {
        //TODO Perhaps log to a logging service or something
        console.log(err.message);
        return Observable_1.Observable.throw(err.message); //throwing error to calling code
    };
    ;
    return ProductsService;
}());
ProductsService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [typeof (_a = typeof http_1.HttpClient !== "undefined" && http_1.HttpClient) === "function" && _a || Object])
], ProductsService);
exports.ProductsService = ProductsService;
var _a;
//# sourceMappingURL=products.service.js.map

/***/ }),

/***/ "../../../../../src/environments/environment.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.
Object.defineProperty(exports, "__esModule", { value: true });
exports.environment = {
    production: false
};
//# sourceMappingURL=environment.js.map

/***/ }),

/***/ "../../../../../src/main.ts":
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__("../../../core/@angular/core.es5.js");
var platform_browser_dynamic_1 = __webpack_require__("../../../platform-browser-dynamic/@angular/platform-browser-dynamic.es5.js");
var app_module_1 = __webpack_require__("../../../../../src/app/app.module.ts");
var environment_1 = __webpack_require__("../../../../../src/environments/environment.ts");
if (environment_1.environment.production) {
    core_1.enableProdMode();
}
platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_module_1.AppModule)
    .catch(function (err) { return console.log(err); });
//# sourceMappingURL=main.js.map

/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("../../../../../src/main.ts");


/***/ })

},[0]);
//# sourceMappingURL=main.bundle.js.map