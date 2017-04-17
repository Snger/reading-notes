## 在CORS标准之前一般用什么方式去跨域获取资源？
1. 对于web开发来讲，由于浏览器的同源策略，我们需要经常使用一些hack的方法去跨域获取资源，但是hack的方法总归是hack。直到W3C出了一个标准－CORS－”跨域资源共享”（Cross-origin resource sharing）。

## 什么是CORS？
1. W3C出了一个标准－CORS－”跨域资源共享”（Cross-origin resource sharing）。<br/>它允许浏览器向跨源服务器，发出XMLHttpRequest请求，从而克服了AJAX只能同源使用的限制。
2. 首先来说 CORS 需要浏览器和服务端同时支持的，对于兼容性来说主要是ie10+，其它现代浏览器都是支持的。

## CORS的请求分几种？
1. CORS 的请求分两种（1.简单请求（simple request）2.非简单请求），这也是浏览器为了安全做的一些处理，不同情况下浏览器执行的操作也是不一样的，主要分为两种请求，当然这一切我们是不需要做额外处理的，浏览器会自动处理的。

## CORS简单请求需要满足什么条件？
1. 请求方法是以下三种方法中的一个：HEAD、GET、POST；
2. HTTP的头信息不超出以下几种字段：Accept、Accept-Language、Content-Language、Last-Event-ID、Content-Type：只限于三个值application/x-www-form-urlencoded、multipart/form-data、text/plain

## CORS简单请求的过程是怎样的？
1. 对于简单的跨域请求，浏览器会自动在请求的头信息加上 Origin 字段，表示本次请求来自哪个源（协议 + 域名 + 端口），服务端会获取到这个值，然后判断是否同意这次请求并返回。
>> 1.服务端允许：如果服务端许可本次请求，就会在返回的头信息多出三个带有 Access-Control 开头的字段;
>> 2.服务端拒绝:当然我们为了防止接口被乱调用，需要限制源，对于不允许的源，服务端还是会返回一个正常的HTTP回应，但是不会带上 Access-Control-Allow-Origin 字段，浏览器发现这个跨域请求的返回头信息没有该字段，就会抛出一个错误，会被 XMLHttpRequest 的 onerror 回调捕获到。<b>这种错误无法通过 HTTP 状态码判断，因为回应的状态码有可能是200</b>

## 如果服务端许可本次CORS简单请求，会在返回的头信息多出哪几个字段？
1. 示例：<br/>Access-Control-Allow-Origin: https://api.qiutc.me <br/> Access-Control-Allow-Credentials: true <br/> Access-Control-Expose-Headers: Info <br/> Content-Type: text/html; charset=utf-8

## 服务端许可的CORS简单请求，多返回的字段各表示什么意思？	1. Access-Control-Allow-Origin 必须。它的值是请求时Origin字段的值或者 *，表示接受任意域名的请求。<br/> 2. Access-Control-Allow-Credentials；可选。它的值是一个布尔值，表示是否允许发送Cookie。默认情况下，Cookie不包括在CORS请求之中。设为true，即表示服务器明确许可，Cookie可以包含在请求中，一起发给服务器。<br/>再需要发送cookie的时候还需要注意要在AJAX请求中打开withCredentials属性：var xhr = new XMLHttpRequest(); xhr.withCredentials = true; <br/>需要注意的是，如果要发送Cookie，Access-Control-Allow-Origin就不能设为*，必须指定明确的、与请求网页一致的域名。同时，Cookie依然遵循同源政策，只有用服务器域名设置的Cookie才会上传，其他域名的Cookie并不会上传，且原网页代码中的document.cookie也无法读取服务器域名下的Cookie。<br/> 3. Access-Control-Expose-Headers :可选。CORS请求时，XMLHttpRequest对象的getResponseHeader()方法只能拿到6个基本字段：Cache-Control、Content-Language、Content-Type、Expires、Last-Modified、Pragma。如果想拿到其他字段，就必须在Access-Control-Expose-Headers里面指定。上面的例子指定，getResponseHeader('Info')可以返回Info字段的值。

要满足CORS非简单请求需要满足什么条件？	除了简单请求以外的CORS请求。非简单请求是那种对服务器有特殊要求的请求，比如请求方法是PUT或DELETE，或者Content-Type字段的类型是application/json。

CORS非简单请求的过程是怎样的？	1）预检请求 <br/>非简单请求的CORS请求，会在正式通信之前，增加一次HTTP查询请求，称为”预检”请求（preflight）。<br/>浏览器先询问服务器，当前网页所在的域名是否在服务器的许可名单之中，以及可以使用哪些HTTP动词和头信息字段。只有得到肯定答复，浏览器才会发出正式的XMLHttpRequest请求，否则就报错。<br/>  2）浏览器的正常请求和回应 <br/>一旦服务器通过了”预检”请求，以后每次浏览器正常的CORS请求，就都跟简单请求一样，会有一个Origin头信息字段。服务器的回应，也都会有一个Access-Control-Allow-Origin头信息字段。

非简单请求的CORS的”预检”请求（preflight）的请求方法是什么？	“预检”请求用的请求方法是OPTIONS，表示这个请求是用来询问的。

非简单请求的CORS的”预检”请求（preflight）会多加哪几个字段？	1. Origin字段：头信息里面，关键字段是Origin，表示请求来自哪个源。<br/>  2. Access-Control-Request-Method ：该字段是必须的，用来列出浏览器的CORS请求会用到哪些HTTP方法，上例是PUT。<br/>  3. Access-Control-Request-Headers : 该字段是一个逗号分隔的字符串，指定浏览器CORS请求会额外发送的头信息字段，上例是X-Custom-Header。

非简单请求的CORS的”预检”请求（preflight）的返回会有哪些对应字段？	1. Access-Control-Allow-Methods  必需，它的值是逗号分隔的一个字符串，表明服务器支持的所有跨域请求的方法。注意，返回的是所有支持的方法，而不单是浏览器请求的那个方法。这是为了避免多次”预检”请求。<br/>  2. Access-Control-Allow-Headers : 如果浏览器请求包括Access-Control-Request-Headers字段，则Access-Control-Allow-Headers字段是必需的。它也是一个逗号分隔的字符串，表明服务器支持的所有头信息字段，不限于浏览器在”预检”中请求的字段。<br/>  3. Access-Control-Max-Age  : 该字段可选，用来指定本次预检请求的有效期，单位为秒。上面结果中，有效期是20天（1728000秒），即允许缓存该条回应1728000秒（即20天），在此期间，不用发出另一条预检请求。

Access-Control-Max-Age: <delta-seconds> 各浏览器的最大值是多少？	<delta-seconds> Maximum number of seconds the results can be cached. Firefox caps this at 24 hours (86400 seconds) and Chromium at 10 minutes (600 seconds). Chromium also specifies a default value of 5 seconds.

什么是jsonp？	sonp = json + padding  <br/>其实对于常用性来说，jsonp应该是使用最经常的一种跨域方式了，他不受浏览器兼容性的限制。但是他也有他的局限性，只能发送 GET 请求，需要服务端和前端规定好，写法丑陋。  <br/>它的原理在于浏览器请求 script 资源不受同源策略限制，并且请求到 script 资源后立即执行。

jsonp一般是怎么实现的？	1. 在浏览器端：首先全局注册一个callback回调函数，记住这个函数名字（比如：resolveJson），这个函数接受一个参数，参数是期望的到的服务端返回数据，函数的具体内容是处理这个数据。<br/>然后动态生成一个 script 标签，src 为：请求资源的地址＋获取函数的字段名＋回调函数名称，这里的获取函数的字段名是要和服务端约定好的，是为了让服务端拿到回调函数名称。（如：www.qiute.com?callbackName=resolveJson）。<br/>  2. 服务端: 在接受到浏览器端 script 的请求之后，从url的query的callbackName获取到回调函数的名字，例子中是resolveJson。然后动态生成一段javascript片段（resolveJson({name: 'qiutc'});）去给这个函数传入参数执行这个函数。<br/> 3. 执行: 服务端返回这个 script 之后，浏览器端获取到 script 资源，然后会立即执行这个 javascript，也就是上面那个片段。这样就能根据之前写好的回调函数处理这些数据了。 4.备注：在一些第三方库往往都会封装jsonp的操作，比如 jQuery 的$.getJSON。

一个页面框架（iframe／frame）之间（父子或同辈），是能够获取到彼此的什么内容？	一个页面框架（iframe／frame）之间（父子或同辈），是能够获取到彼此的window对象的，但是这个 window 不能拿到方法和属性。

用document.domain实现跨域的前提条件是什么？	这两个域名必须属于同一个基础域名!而且所用的协议，端口都要一致。<br/>  但要注意的是，document.domain 的设置是有限制的，我们只能把 document.domain 设置成自身或更高一级的父域，且主域必须相同。例如：a.b.example.com 中某个文档的 document.domain 可以设成a.b.example.com、b.example.com、example.com中的任意一个，但是不可以设成 c.a.b.example.com,因为这是当前域的子域，也不可以设成baidu.com,因为主域已经不相同了。

用document.domain如何实现跨域？	我们只要把 https://blog.qiutc.me/a.html 和 https://www.qiutc.me/b.html 这两个页面的 document.domain 都设成相同的域名就可以了（例如：document.domain = 'qiutc.me';）。这样我们就可以通过js访问到iframe中的各种属性和对象了。例如 var doc = document.getElementById('iframe').contentWindow.document; // 能获取到

window.name属性有什么特征？	在一个窗口(window)的生命周期内,窗口载入的所有的页面都是共享一个 window.name 的，每个页面对 window.name 都有读写的权限，window.name 是持久存在一个窗口载入过的所有页面中的，并不会因新页面的载入而进行重置。<br/>  <b>window.name 的美妙之处：name 值在不同的页面（甚至不同域名）加载后依旧存在，并且可以支持非常长的 name 值（2MB）。</b>

如何使用 window.name 解决跨域问题？	1. name 在浏览器环境中是一个全局/window对象的属性，且当在 frame 中加载新页面时，name 的属性值依旧保持不变。通过在 iframe 中加载一个资源，该目标页面将设置 frame 的 name 属性。此 name 属性值可被获取到，以访问 Web 服务发送的信息。但 name 属性仅对相同域名的 frame 可访问。这意味着为了访问 name 属性，当远程 Web 服务页面被加载后，必须导航 frame 回到原始域。同源策略依旧防止其他 frame 访问 name 属性。一旦 name 属性获得，销毁 frame 。<br/>  在最顶层，name 属性是不安全的，对于所有后续页面，设置在 name 属性中的任何信息都是可获得的。然而 windowName 模块总是在一个 iframe 中加载资源，并且一旦获取到数据，或者当你在最顶层浏览了一个新页面，这个 iframe 将被销毁，所以其他页面永远访问不到 window.name 属性。<br/><br/>    2. 在 a.html 页面中使用一个隐藏的 iframe 来充当一个中间人角色，由 iframe 去获取 data.html 的数据，然后 a.html 再去得到 iframe 获取到的数据。<br/>  充当中间人的 iframe 想要获取到data.html的通过window.name设置的数据，只需要把这个iframe的src设为www.qiutc.com/data.html就行了。然后a.html想要得到iframe所获取到的数据，也就是想要得到iframe的window.name的值，还必须把这个iframe的src设成跟a.html页面同一个域才行，不然根据前面讲的同源策略，a.html是不能访问到iframe里的window.name属性的。这就是整个跨域过程。

简单介绍下window.postMessage？	window.postMessage(message, targetOrigin) 方法是html5新引进的特性，可以使用它来向其它的window对象发送消息，无论这个window对象是属于同源或不同源。

如何使用window.postMessage实现跨域？	调用postMessage方法的window对象是指要接收消息的那一个window对象，该方法的第一个参数message为要发送的消息，类型只能为字符串；第二个参数targetOrigin用来限定接收消息的那个window对象所在的域，如果不想限定域，可以使用通配符 * 。<br/> 需要接收消息的window对象，可是通过监听自身的message事件来获取传过来的消息，消息内容储存在该事件对象的data属性中。

简单介绍下CSST (CSS Text Transformation)？	CSST (CSS Text Transformation)一种用 CSS 跨域传输文本的方案。<br/> 优点：相比 JSONP 更为安全，不需要执行跨站脚本。<br/> 缺点：没有 JSONP 适配广，CSST 依赖支持 CSS3 的浏览器。<br/> 原理：通过读取 CSS3 content 属性获取传送内容。<br/> 具体可以参考：CSST (CSS Text Transformation)