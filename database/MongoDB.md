## install
[link](https://www.mongodb.com/download-center/v2/community)

## Step
- 压缩包复制到 D:/App/MongoDB-4.0.3
- alias mongopath='cd /d/App/MongoDB-4.0.3/bin/'
- 测试 mongodb： bin/mongod --dbpath ../data/db
- http://localhost:27017/

## 连接MongoDB
- 我们可以在命令窗口中运行 mongo.exe 命令即可连接上 MongoDB，执行如下命令：
C:\mongodb\bin\mongo.exe

## 配置 MongoDB 服务
- mkdir data & cd data & mkdir db
- mkdir log
- vi mongod.cfg
````config
systemLog:
    destination: file
    path: D:\App\MongoDB-4.0.3\data\log\mongod.log
storage:
    dbPath: D:\App\MongoDB-4.0.3\data\db
````
````cmd
./bin/mongod.exe --config "D:\App\MongoDB-4.0.3\mongod.cfg" --install --serviceName "MongoDB"
````
- 启动MongoDB服务
`net start MongoDB`
- 关闭MongoDB服务
`net stop MongoDB`
- 移除 MongoDB 服务
`C:\mongodb\bin\mongod.exe --remove`

## MongoDB 后台管理 Shell
- 如果你需要进入MongoDB后台管理，你需要先打开mongodb装目录的下的bin目录，然后执行mongo.exe文件，MongoDB Shell是MongoDB自带的交互式Javascript shell,用来对MongoDB进行操作和管理的交互式环境。
- 当你进入mongoDB后台后，它默认会链接到 test 文档（数据库）：
````cmd
> mongo
MongoDB shell version: 3.0.6
connecting to: test
……
````
- 由于它是一个JavaScript shell，您可以运行一些简单的算术运算:
````cmd
> 2 + 2
4
>
````
- db 命令用于查看当前操作的文档（数据库）：
````cmd
> db
test
````
- 插入一些简单的记录并查找它：
````cmd
> db.runoob.insert({x:10})
WriteResult({ "nInserted" : 1 })
> db.runoob.find()
{ "_id" : ObjectId("5604ff74a274a611b0c990aa"), "x" : 10 }
````
- 第一个命令将数字 10 插入到 runoob 集合的 x 字段中。
