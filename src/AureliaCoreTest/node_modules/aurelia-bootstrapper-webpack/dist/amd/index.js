define(['exports', './aurelia-bootstrapper-webpack'], function (exports, _aureliaBootstrapperWebpack) {
  'use strict';

  Object.defineProperty(exports, "__esModule", {
    value: true
  });
  Object.keys(_aureliaBootstrapperWebpack).forEach(function (key) {
    if (key === "default" || key === "__esModule") return;
    Object.defineProperty(exports, key, {
      enumerable: true,
      get: function () {
        return _aureliaBootstrapperWebpack[key];
      }
    });
  });
});