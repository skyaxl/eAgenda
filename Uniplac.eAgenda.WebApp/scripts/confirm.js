angular.module('angular-native-confirm')
  .service('Confirm', function ($window) {
      return {
          action: function (message, successCb, canceledCb) {
              var hasActionBeenConfirmed = $window.confirm(message);

              if (hasActionBeenConfirmed) {
                  return _.isFunction(successCb) && successCb();
              }

              return _.isFunction(canceledCb) && canceledCb();
          }
      };
  });