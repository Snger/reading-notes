# nodejs
<!-- MarkdownTOC -->

- How do I debug Node.js applications?
- install v8.9.3
- How to clear console
- Writing files in Node.js
- Install step is run on optional package not supported by OS
- nvm
- How Can I Wait In Node.js \(Javascript\), l need to pause for a period of time
- write/add data in JSON file using node.js
- How to exit in Node.js

<!-- /MarkdownTOC -->

## How do I debug Node.js applications?
1. node-inspector could save the day! Use it from any browser supporting WebSocket. Breakpoints, profiler, livecoding, etc... It is really awesome.
> Install it with:
> npm install -g node-inspector
> Then run:
> node-debug app.js
2. Node has its own built in GUI debugger as of version 6.3 (using Chrome's DevTools), Simply pass the inspector flag and you'll be provided with a URL to the inspector:
> node --inspect server.js
> You can also break on the first line by passing --inspect-brk instead.
> To open a Chrome window automatically, use the inspect-process module.
````command line
# install inspect-process globally
npm install -g inspect-process
# start the debugger with inspect
inspect script.js
````
3. Node.js version 0.3.4+ has built-in debugging support.
> node debug script.js
> Manual: http://nodejs.org/api/debugger.html

## install v8.9.3
> gyp: Visual Studio 2017 requires any SDK of ['v10.0', 'v8.1'] version,
>> reason: [gyp source code](https://chromium.googlesource.com/external/gyp/+/master/pylib/gyp/MSVSVersion.py#269)
>> [node-gyp issue - node-gyp](https://github.com/nodejs/node-gyp/issues/1056)
>> npm install -g node-gyp
> gyp: name 'MSVS_VERSION' is not defined
>> [Detect MSVC version in GYP](https://stackoverflow.com/questions/26311665/detect-msvc-version-in-gyp#32329465)
>> `nvm install v8.9.4 –msvs_version=2017`
>> [node merged - win: enable build with vs2017](https://github.com/nodejs/node/pull/11852/files)

## How to clear console
````nodejs
process.stdout.write('\033c');
process.stdout.write("\u001b[2J\u001b[0;0H");
// util
var util = require('util');
util.print("\u001b[2J\u001b[0;0H");
````

## Writing files in Node.js
> Currently there are three ways to write a file:
1. [`fs.write(fd, buffer, offset, length, position, callback`)][1001]
   You need to wait for the callback to ensure that the buffer is written to disk. It's not buffered.
2. [`fs.writeFile(filename, data, [encoding], callback)`][1002]
   All data must be stored at the same time; you cannot perform sequential writes.
3. [`fs.createWriteStream(path, [options]`)][1003]
   Creates a [`WriteStream`][1004], which is convenient because you don't need to wait for a callback. But again, it's not buffered.
> A [`WriteStream`][1004], as the name says, is a stream. A stream by definition is “a buffer” containing data which moves in one direction (source ► destination). But a writable stream is not necessarily “buffered”. A stream is “buffered” when you write `n` times, and at time `n+1`, the stream sends the buffer to the kernel (because it's full and needs to be flushed).
> **In other words:** “A buffer” is the object. Whether or not it “is buffered” is a property of that object.
> If you look at the code, the `WriteStream` inherits from a writable `Stream` object. If you pay attention, you’ll see how they flush the content; they don't have any buffering system.
> If you write a string, it’s converted to a buffer, and then sent to the native layer and written to disk. When writing strings, they're not filling up any buffer. So, if you do:
    write("a")
    write("b")
    write("c")
> You're doing:
    fs.write(new Buffer("a"))
    fs.write(new Buffer("b"))
    fs.write(new Buffer("c"))
> That’s *three* calls to the I/O layer. Although you're using “buffers”, the data is not buffered. A buffered stream would do: `fs.write(new Buffer ("abc"))`, one call to the I/O layer.
> As of now, in Node.js v0.12 (stable version announced 02/06/2015) now supports two functions:
> [`cork()`](http://nodejs.org/docs/v0.11.5/api/stream.html#stream_writable_cork) and
> [`uncork()`](http://nodejs.org/docs/v0.11.5/api/stream.html#stream_writable_uncork). It seems that these functions will finally allow you to buffer/flush the write calls.
> For example, in Java there are some classes that provide buffered streams (`BufferedOutputStream`, `BufferedWriter`...). If you write three bytes, these bytes will be stored in the buffer (memory) instead of doing an I/O call just for three bytes. When the buffer is full the content is flushed and saved to disk. This improves performance.
> I'm not discovering anything, just remembering how a disk access should be done.
  [1001]: http://nodejs.org/api/fs.html#fs_fs_write_fd_buffer_offset_length_position_callback
  [1002]: http://nodejs.org/api/fs.html#fs_fs_writefile_filename_data_options_callback
  [1003]: http://nodejs.org/api/fs.html#fs_fs_createwritestream_path_options
  [1004]: https://github.com/joyent/node/blob/master/lib/fs.js#L1623

## Install step is run on optional package not supported by OS
> https://github.com/yarnpkg/yarn/issues/1217
> yarn install --ignore-optional

<<<<<<< HEAD
## nvm
> 临时切换，当你开启新的terminal窗口的时候就失效
> nvm use stable
> 彻底的切换
> nvm alias default xxxx

## How Can I Wait In Node.js (Javascript), l need to pause for a period of time
> A new answer to an old question. Today ( Jan 2017 June 2019) it is much easier. You can use the new async/await syntax. For example:
````javascript
async function init(){
   console.log(1)
   await sleep(1000)
   console.log(2)
}
function sleep(ms){
    return new Promise(resolve=>{
        setTimeout(resolve,ms)
    })
}
````

## write/add data in JSON file using node.js
> If this json file won't become too big over the time you should try:
Create a javascript object with the table array in it
````javascript
var obj = {
   table: []
};
````
> Add some data to it like
`obj.table.push({id: 1, square:2});`
> Convert it from an object to string with stringify
`var json = JSON.stringify(obj);`
> use fs to write the file to disk
````javascript
var fs = require('fs');
fs.writeFile('myjsonfile.json', json, 'utf8', callback);
````
> if you want to append it read the json file and convert it back to an object
````javascript
fs.readFile('myjsonfile.json', 'utf8', function readFileCallback(err, data){
    if (err){
        console.log(err);
    } else {
    obj = JSON.parse(data); //now it an object
    obj.table.push({id: 2, square:3}); //add some data
    json = JSON.stringify(obj); //convert it back to json
    fs.writeFile('myjsonfile.json', json, 'utf8', callback); // write it back 
}});
````
> This will work for data big as 100 MB max effectively. Over this limit, you should use a database engine.
> UPDATE: Create a function which returns the current date (year+month+day) as a string. Create the file named this string + .json. the fs module has a function which can check for file existence named fs.stat(path, callback). With this, you can check if the file exists. If it exists, use the read function if it's not, use the create function. Use the date string as the path cuz the file will be named as the today date + .json. the callback will contain a stats object which will be null if the file does not exist.

## How to exit in Node.js
> Call the global process object's exit method:
`process.exit()`
> From the docs:
`process.exit([code])`
> Ends the process with the specified code. If omitted, exit uses the 'success' code 0.
> To exit with a 'failure' code:
`process.exit(1);`
> The shell that executed node should see the exit code as 1.
>>>>>>> b2b1b481dec060be3e51e3bdf55dfc8994601df3
