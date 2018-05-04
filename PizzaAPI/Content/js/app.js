var app = angular.module("app", []);
var LocalStorageObject = (function () {

    var _get = function(itemName) {

    var _localStorageItem = false;

    if (window.localStorage) {
        _localStorageItem = localStorage.getItem(itemName);
    }

    return _localStorageItem;

    };

    var _set = function(key, data) {

        var _key = key;
        var _data = data;
        var _is_localstorage_set = false;
        console.log(_key, _data);
        if (window.localStorage){

            if (_data) {
              _is_localstorage_set = true;
                localStorage.setItem(_key, _data)
            }
        }

        return _is_localstorage_set;
    }

return {
    get: _get,
    set: _set
}
})();

app.constant("APIURL", (function(){
var _protocol = window.location.protocol;
var _hostname = window.location.hostname;
var _port = 59445;
var _url = _protocol + '//' + _hostname + ':' + _port;

return {
	protocol: _protocol,
	hostname: _hostname,
	port: _port,
	url: _url
}
})());

app.factory("SessionModel", function(){

    var _currentUser = JSON.parse(LocalStorageObject.get("current_user"));
    var _cart = JSON.parse(LocalStorageObject.get("pizza_cart"));


    var _session_model = {
        session_active: false,
        current_user: {},
        cart: {}
    };

    if (_currentUser) {
      _session_model.current_user = _currentUser;
      _session_model.session_active = true;
    }

    if (_cart) {
        _session_model.cart = _cart;
    }

return _session_model
});

app.factory("DataModel", function(){

    var _loginUserModel = {
		username: "",
		password: "",
	}
	
	var _registerUserModel = {
		username: "",
        password: "",
        confirmPassword: ""
	}

	var _state = {
		checkout: false,
        submitted: false
	};
	
	var _pizzas = [];
	var _toppings = [];

	var _data_model = {
		login_user_model: _loginUserModel,
		register_user_model: _registerUserModel,
		state:_state,
		pizzas: _pizzas,
		toppings: _toppings
	}
	
return _data_model;
});

app.service("PizzaService", ["$http", "$q", "APIURL", "DataModel", function($http, $q, APIURL, DataModel){
	
	var _get_pizzas = function() {
		
		var _deferred = $q.defer();
		var _pizzas = [];
		var _unique_pizzas = [];
		var _pizzaNames = [];
		var _api_urls = {
			pizza_url : APIURL.url + "/api/v1/Pizzas",
			pizza_url_v2 : APIURL.url + "/api/v1/Pizzas"
		}
		var _map_avaliable_pizza_sizes = function(data) {
		
		var _pizzaList = [];
		var _mapped_object = {
			pizza_name: "",
			pizza_sizes: [],
			pizza: {}
		};
		var _tempName = "";
		var _oldPizza = {};
		var _pizzaSizes = [];
		
		$.map( data.AllPizzas, function( n ) {
				
				if (n.Name !== _tempName) {
					
					if (_tempName !== "") {
						//add to array, add array to list and clear old
						_pizzaList.push({
							pizza_name: _tempName,
							pizza_sizes: _pizzaSizes,
							current_pizza: _oldPizza,
							extra_toppings: {
								active: false,
								toppings: {}
							}
						});
						_pizzaSizes = [];
						_oldPizza = {};
					} 
				}
				
				_pizzaSizes.push({size: n.Size, price: n.Price, pizza_id: n.Id});
				_tempName = n.Name;
				_oldPizza = n;
			});
			
			_pizzaList.push({
                pizza_name: _tempName,
                pizza_sizes: _pizzaSizes,
                current_pizza: _oldPizza,
                extra_toppings: {
                    active: false,
                    toppings: {}
                }
            });
			
			return _pizzaList;
		}
		var _handle_success = function (response) {
            
			var _pizzas = response.data;
			var _combined_by_size = {};
			
			if (!_pizzas) {
				 
				return _deferred.reject({
					error: true,
					message: "Problem retreiving Pizzas"
				})
			}
				
			_combined_by_size = _map_avaliable_pizza_sizes(_pizzas);
			console.log(_combined_by_size);
			_deferred.resolve({
				pizzas:  _pizzas,
				combined_by_size : _combined_by_size
			});
        }
		
		$http.get(_api_urls.pizza_url_v2).then(_handle_success);
		
		return _deferred.promise;
	}
	var _get_pizza = function(id) {
		
		var _api_urls = {
			pizza_url : APIURL.url + "/api/v1/Pizza/" + id
		}
		var _deferred = $q.defer();
		var _handle_success = function (response) {
            
			var _pizza = response.data;
			
			if (!_pizza) {
				 
				  _deferred.reject({
					error: true,
					message: "Problem retreiving Pizza"
				})
			}
				
			 _deferred.resolve(_pizza);
			
        }
		
		console.log(id);
		
		if (id) {
			$http.get(_api_urls.pizza_url).then(_handle_success);		
		}
		
		return _deferred.promise;
		
	}
	
	return {
		get_pizzas : _get_pizzas,
		get_pizza : _get_pizza
	}
}]);
app.service("ToppingService", ["$http", "$q", "APIURL", function($http, $q, APIURL){
	
	var _get_toppings = function() {
		
		var _deferred = $q.defer();
		var _pizzas = [];
		var _unique_pizzas = [];
		var _pizzaNames = [];
		var _api_urls = {
			topping_url : APIURL.url + "/api/v1/Toppings",
		}	
		var _handle_success = function (response) {
            
			var _toppings = response.data;

			if (!_toppings) {
				 
				return _deferred.reject({
					error: true,
					message: "Problem retreiving Toppings"
				})
			}
				
		
			
			_deferred.resolve({
				toppings:  _toppings,
			});
        }
		
		$http.get(_api_urls.topping_url).then(_handle_success);
		
		return _deferred.promise;
	}
	var _get_toppings_by_size = function(size) {
		
		var _deferred = $q.defer();
		var _pizzas = [];
		var _unique_pizzas = [];
		var _pizzaNames = [];
		var _api_urls = {
			topping_url : APIURL.url + "/api/v1/Toppings/",
		}
		var _map_toppings = function(data) {
			
			var _data = data;
			var _mapped_toppings = [];
			
			if (_data) {
				$.map(_data, function(topping) {
					_mapped_toppings.push({
						id: topping.ToppingId,
						size: topping.Size,
						price: topping.Price,
						name: topping.Name,
						active: false
					});
				});	
			}
			
			console.log(_mapped_toppings);
			return _mapped_toppings;
		}
		var _handle_success = function (response) {
            
			var _toppings = _map_toppings(response.data);
			
			if (!_toppings) {
				 
				return _deferred.reject({
					error: true,
					message: "Problem retreiving Toppings"
				})
			}
				
			_deferred.resolve(_toppings);
        }
		
		$http.get(_api_urls.topping_url + size).then(_handle_success);
		
		return _deferred.promise;
	}
		
	return {
		get_toppings : _get_toppings,
		get_toppings_by_size : _get_toppings_by_size
	}
}]);
app.service("CartService", ["$http", "$q", "APIURL", function($http, $q, APIURL){
		
	var _add_voucher = function(order, voucher) {
		
		var _deferred = $q.defer();
		var _order = order;
		var _voucher = voucher;

		$http({
            method: 'POST',
            url: $scope.apiURL + '/api/v1/AddCoupon',
            data: {
                Order: _order,
                VoucherCode: _voucher
            },
            headers: {
                "Content-Type": "application/json",
                Authorization: $scope.currentUser.access_token ? $scope.currentUser.token_type + ' ' + $scope.currentUser.access_token : ""
            },
        }).then(function(response) {
			console.log(response);
			_deferred.resolve(response);
		});
		
		return _deferred;
	}
		
	return {
		add_voucher : _add_voucher,
		get_toppings_by_size : _get_toppings_by_size
	}
}]);
app.controller('MainController', ['$scope', '$http', 'SessionModel', 'APIURL', 'DataModel', 'PizzaService', 'ToppingService', 'CartService',  ($scope, $http, SessionModel, APIURL, DataModel, PizzaService, ToppingService, CartService) {
    
	$scope.currentUser = SessionModel.current_user;
    $scope.cart = SessionModel.cart;
    $scope.apiURL = APIURL.url;
    $scope.loginUserModel = DataModel.login_user_model;
    $scope.registerUserModel =  DataModel.register_user_model;
    $scope.state =  DataModel.state;
    $scope.pizzas =  DataModel.pizzas;
    $scope.toppings =  DataModel.toppings;
	$scope.apiURL = APIURL.url;

    function init() {
        
		PizzaService.get_pizzas().then(function(response) {
			DataModel.pizzas = response;
			$scope.pizzas = response;
		});
      
		ToppingService.get_toppings().then(function(response) {
		
			DataModel.pizzas = response;
			$scope.toppings = response.data;
		});

        $scope.getOrderHistory();
    }
	
    window.onload = init;

    $scope.applyTheCart = function (order) {
        $scope.cart = order;
        LocalStorageObject.set("pizza_cart", JSON.stringify(order));
    }
    $scope.applyVoucher = CartService.add_voucher(order).then(function(response) {
		console.log("order", order);
		console.log("response", response);
	});
    $scope.reorder = function (order) {
        order.CurrentVoucher = "";
        order.Discount = 0;
        $scope.applyTheCart(order);

    };
	$scope.getAdditionalToppings = function(pizza) {
		
		var _current_pizza = pizza.current_pizza;
		
		if (!_current_pizza) {
			return;
		}
		
		ToppingService.get_toppings_by_size(_current_pizza.Size).then(function(response) {
			pizza.extra_toppings.active = true;
			pizza.extra_toppings.toppings = response;
		});
	}
    $scope.selectedPizzaSize = function (pizza, size) {
		
		var _size = size;
		var _handle_success = function(new_pizza) {
			
			var _pizza = new_pizza;
		
			if (_pizza) {
				pizza.current_pizza = _pizza;
				pizza.extra_toppings.active = false;
				pizza.extra_toppings.toppings = {};
			}
        };
        
		if (!_size) {
			return;
		}
		PizzaService.get_pizza(_size.pizza_id).then(_handle_success);
    };
    $scope.applyDelivery = function (value) {
        $http({
            method: 'POST',
            url: $scope.apiURL + '/api/v1/ApplyDelivery',
            data: {
                Delivery: value,
                Order: $scope.cart
            },
            headers: {
                "Content-Type": "application/json",
                Authorization: $scope.currentUser.access_token ? $scope.currentUser.token_type + ' ' + $scope.currentUser.access_token : ""
            },
        }).then(function (response) {
            $scope.applyTheCart(response.data);
        });
    }
    $scope.resetCart = function () {
        $http({
            method: 'DELETE',
            url: $scope.apiURL + '/api/v1/ResetCart',
            headers: {
                "Content-Type": "application/json",
                Authorization: $scope.currentUser.access_token ? $scope.currentUser.token_type + ' ' + $scope.currentUser.access_token : ""
            },
        }).then(function (response) {
            $scope.applyTheCart(response.data);
        });
    };
    $scope.login = function () {
        $http({
            method: 'POST',
            url: $scope.apiURL + '/token',
            data: 'grant_type=password&username=' + $scope.loginUserModel.username + '&password=' + $scope.loginUserModel.password,
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
            },
        }).then(function (response) {
            $scope.currentUser = response.data;
            $scope.getOrderHistory();
            LocalStorageObject.set("current_user", JSON.stringify($scope.currentUser));
        });
    };
    $scope.logout = function () {
        $http({
            method: 'POST',
            url: $scope.apiURL + '/api/Account/Logout',
            headers: {
                "Content-Type": "application/json",
                Authorization: $scope.currentUser.access_token ? $scope.currentUser.token_type + ' ' + $scope.currentUser.access_token : ""
            },
        }).then(function () {
            $scope.currentUser = {};
            window.localStorage.setItem("currentUser", JSON.stringify({}));
        });
    };
    $scope.register = function () {
        $http({
            method: 'POST',
            url: $scope.apiURL + '/api/Account/Register',
            data: 'grant_type=password&Email=' + $scope.registerUserModel.username + '&Password=' + $scope.registerUserModel.password + '&ConfirmPassword=' + $scope.registerUserModel.confirmPassword,
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
            },
        }).then(function (response) {
            $scope.loginUserModel.username = $scope.registerUserModel.username;
            $scope.loginUserModel.password = $scope.registerUserModel.password;
            $scope.login();
        });
    };
    $scope.getOrderHistory = function () {
        if ($scope.currentUser.access_token) {
            $http({
                method: 'GET',
                url: $scope.apiURL + '/api/v1/Orders',
                headers: {
                    "Content-Type": "application/json",
                    Authorization: $scope.currentUser.access_token ? $scope.currentUser.token_type + ' ' + $scope.currentUser.access_token : ""
                },
            }).then(function (response) {
                console.log({ response });

                $scope.currentUser.orders = response.data;
            });
        }
    };
    $scope.addToCart = function (pizza) {

        var _map_active_toppings = function(extraToppings) {

            var _active_extra_toppings = [];
            if (!extraToppings || extraToppings.length === 0) {
                return;
            }

            extraToppings.forEach(function(topping){
                if (topping.active) {
                    _active_extra_toppings.push(topping);
                }
            });

            return _active_extra_toppings;
        }
        var _pizza = pizza.current_pizza;
        var _extra_toppings = pizza.extra_toppings.toppings;
        
        $http({
            method: 'POST',
            url: $scope.apiURL + '/api/v1/AddToCart',
            data: {
                Pizza: _pizza,
                AdditionalToppings: _map_active_toppings(_extra_toppings),
                Order: $scope.cart
            },
            headers: {
                "Content-Type": "application/json",
                Authorization: $scope.currentUser.access_token ? $scope.currentUser.token_type + ' ' + $scope.currentUser.access_token : ""
            },
        }).then(function (response) {
            console.log("cart", response);
            $scope.applyTheCart(response.data);
        });
    };
    $scope.removeFromCart = function (item) {
    
        $http({
            method: 'DELETE',
            url: $scope.apiURL + '/api/v1/RemoveFromCart',
            data: {
                Pizza: item.Pizza.Id,
                AdditionalToppings: null,
                Order: $scope.cart,
                OrderItem: item
            },
            headers: {
                "Content-Type": "application/json",
                Authorization: $scope.currentUser.access_token ? $scope.currentUser.token_type + ' ' + $scope.currentUser.access_token : ""
            },
        }).then(function (response) {
            $scope.applyTheCart(response.data);
        });
    };
    $scope.submitOrder = function () {
       
        $http({
            method: 'POST',
            url: $scope.apiURL + '/api/v1/SubmitOrder',
            data: {
                Order: $scope.cart
            },
            headers: {
                "Content-Type": "application/json",
                Authorization: $scope.currentUser.access_token ? $scope.currentUser.token_type + ' ' + $scope.currentUser.access_token : ""
            },
        }).then(function (response) {
            $scope.state.completedOrder = response.data;
            $scope.state.checkout = false;
            $scope.state.submitted = true;
            $scope.resetCart();
        });
    };

}]);
