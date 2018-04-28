# webpack

<!-- MarkdownTOC -->

- Optimising the Vue build - Runtime-only build
- Cannot assign to read only property 'exports' of object '#'
- AMD, CMD, CommonJS和UMD

<!-- /MarkdownTOC -->

## Optimising the Vue build - Runtime-only build
1. If you’re only using render functions in your Vue app, and no HTML templates, you don’t need Vue’s template compiler. You can reduce your bundle size by omitting the compiler from the Webpack build.
1. There is a runtime-only build of the Vue.js library that includes all the features of Vue.js except the template compiler, called vue.runtime.js. It’s about 20KB smaller than the full build so it’s worth using if you can.
1. The runtime-only build is used by default, so every time you use import vue from 'vue'; in your project that’s what you’ll get. You can change to a different build, though, by using the alias configuration option:
````
resolve: {
  alias: {
    'vue$': 'vue/dist/vue.esm.js' // Use the full build (or vue.common.js)
  }
}
````

## Cannot assign to read only property 'exports' of object '#<Object>'
> This issue was newly affecting me after instructing Babel to not transpile module syntax. As sokra described, it only occurred when trying to use CommonJS style module.exports inside of ES modules. require always works. This can be fixed by simply replacing all module.exports = ... to export default ... where applicable, as this is seemingly equivalent for old Babel-style ES module transpilation. (Note though, that importing this module using require will probably give you an option with a default key rather than the default export itself, so it's probably best you make the switch across the entire codebase at once.)

## AMD, CMD, CommonJS和UMD
> [link](https://segmentfault.com/a/1190000004873947)
> - Javascript模块化
在了解这些规范之前，还是先了解一下什么是模块化。
模块化是指在解决某一个复杂问题或者一系列的杂糅问题时，依照一种分类的思维把问题进行系统性的分解以之处理。模块化是一种处理复杂系统分解为代码结构更合理，可维护性更高的可管理的模块的方式。可以想象一个巨大的系统代码，被整合优化分割成逻辑性很强的模块时，对于软件是一种何等意义的存在。对于软件行业来说：解耦软件系统的复杂性，使得不管多么大的系统，也可以将管理，开发，维护变得“有理可循”。
还有一些对于模块化一些专业的定义为：模块化是软件系统的属性，这个系统被分解为一组高内聚，低耦合的模块。那么在理想状态下我们只需要完成自己部分的核心业务逻辑代码，其他方面的依赖可以通过直接加载被人已经写好模块进行使用即可。
首先，既然是模块化设计，那么作为一个模块化系统所必须的能力：
1. 定义封装的模块。
2. 定义新模块对其他模块的依赖。
3. 可对其他模块的引入支持。
好了，思想有了，那么总要有点什么来建立一个模块化的规范制度吧，不然各式各样的模块加载方式只会将局搅得更为混乱。那么在JavaScript中出现了一些非传统模块开发方式的规范 CommonJS的模块规范，AMD（Asynchronous Module Definition），CMD（Common Module Definition）等。
- CommonJS
CommonJS是服务器端模块的规范，Node.js采用了这个规范。
该规范的主要内容是，模块必须通过module.exports 导出对外的变量或接口，通过 require() 来导入其他模块的输出到当前模块作用域中。
根据CommonJS规范，一个单独的文件就是一个模块。加载模块使用require方法，该方法读取一个文件并执行，最后返回文件内部的exports对象。
- AMD和RequireJS
- AMD
AMD是"Asynchronous Module Definition"的缩写，意思就是"异步模块定义".
AMD设计出一个简洁的写模块API：
define(id?, dependencies?, factory);
第一个参数 id 为字符串类型，表示了模块标识，为可选参数。若不存在则模块标识应该默认定义为在加载器中被请求脚本的标识。如果存在，那么模块标识必须为顶层的或者一个绝对的标识。
第二个参数，dependencies ，是一个当前模块依赖的，已被模块定义的模块标识的数组字面量。
第三个参数，factory，是一个需要进行实例化的函数或者一个对象。
不考虑多了一层函数外，格式和Node.js是一样的：使用require获取依赖模块，使用exports导出API。
除了define外，AMD还保留一个关键字require。require 作为规范保留的全局标识符，可以实现为 module loader，也可以不实现。
模块加载
require([module], callback)
AMD模块化规范中使用全局或局部的require函数实现加载一个或多个模块，所有模块加载完成之后的回调函数。
其中：
[module]：是一个数组，里面的成员就是要加载的模块；
callback：是模块加载完成之后的回调函数。
- RequireJS
RequireJS 是一个前端的模块化管理的工具库，遵循AMD规范，它的作者就是AMD规范的创始人 James Burke。所以说RequireJS是对AMD规范的阐述一点也不为过。
RequireJS 的基本思想为：通过一个函数来将所有所需要的或者说所依赖的模块实现装载进来，然后返回一个新的函数（模块），我们所有的关于新模块的业务代码都在这个函数内部操作，其内部也可无限制的使用已经加载进来的以来的模块。
    <script data-main='scripts/main' src='scripts/require.js'></script>
那么scripts下的main.js则是指定的主代码脚本文件，所有的依赖模块代码文件都将从该文件开始异步加载进入执行。
define用于定义模块，RequireJS要求每个模块均放在独立的文件之中。按照是否有依赖其他模块的情况分为独立模块和非独立模块。
- CMD和SeaJS
CMD是SeaJS 在推广过程中对模块定义的规范化产出
对于依赖的模块AMD是提前执行，CMD是延迟执行。不过RequireJS从2.0开始，也改成可以延迟执行（根据写法不同，处理方式不通过）。
CMD推崇依赖就近，AMD推崇依赖前置。
- UMD
UMD是AMD和CommonJS的糅合
AMD模块以浏览器第一的原则发展，异步加载模块。
CommonJS模块以服务器第一原则发展，选择同步加载，它的模块无需包装(unwrapped modules)。
这迫使人们又想出另一个更通用的模式UMD （Universal Module Definition）。希望解决跨平台的解决方案。
UMD先判断是否支持Node.js的模块（exports）是否存在，存在则使用Node.js模块模式。
在判断是否支持AMD（define是否存在），存在则使用AMD方式加载模块。
