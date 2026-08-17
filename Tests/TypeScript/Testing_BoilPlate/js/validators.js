(function (root, factory) {
  if (typeof module === 'object' && typeof module.exports === 'object') {
    module.exports = factory();
  } else {
    root.validators = factory();
  }
}(typeof window !== 'undefined' ? window : global, function(){
  function validateEmail(value){
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value);
  }

  return { validateEmail };
}));
