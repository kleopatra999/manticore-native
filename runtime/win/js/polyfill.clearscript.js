const g = global;
const m = g.manticore;

// Setup the JavaScriptCore runtime to look like what Manticore requires (bind native functions)
m.log('info', 'Loading ClearScript polyfill');

g.exports = g.exports || {};

require('core-js/es6/symbol');
require('core-js/es6/set');
require('core-js/fn/string/includes');
require('core-js/fn/object/is');
require('core-js/fn/object/assign');
require('core-js/fn/array/of');
require('core-js/fn/array/from');
require('core-js/fn/array/find');
require('core-js/fn/array/find-index');
require('core-js/fn/symbol/iterator');

require('../../common/console');
require('../../common/promise');
require('../../common/timer');

m._ = {
  array() {
    return [];
  },
  fn(fnlike, count) {
    return function () {
        const a = arguments;
      switch (count) {
      case 0:
          return fnlike();
        case 1:
          return fnlike(a[0]);
        case 2:
          return fnlike(a[0], a[1]);
        case 3:
          return fnlike(a[0], a[1], a[2]);
        default:
          throw new Error('Do not make callbacks with so many arguments');
      }
    };
  },
  construct: function construct(className, args) {
    if (!className) return {};
    const cons = g.exports[className];
    function F() { return cons.apply(this, args); }
    F.prototype = cons.prototype;
    return new F();
  },
  getClass: function getClass(className) {
    return g.exports[className];
  },
};

require('../../common/fetch');
m.log('info', 'Loaded ClearScript polyfill');