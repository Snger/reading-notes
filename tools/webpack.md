## Optimising the Vue build - Runtime-only build
1. If you’re only using render functions in your Vue app*, and no HTML templates, you don’t need Vue’s template compiler. You can reduce your bundle size by omitting the compiler from the Webpack build.
1. There is a runtime-only build of the Vue.js library that includes all the features of Vue.js except the template compiler, called vue.runtime.js. It’s about 20KB smaller than the full build so it’s worth using if you can.
1. The runtime-only build is used by default, so every time you use import vue from 'vue'; in your project that’s what you’ll get. You can change to a different build, though, by using the alias configuration option:
````
resolve: {
  alias: {
    'vue$': 'vue/dist/vue.esm.js' // Use the full build (or vue.common.js)
  }
}
````

