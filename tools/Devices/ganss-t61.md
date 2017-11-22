# ganss t61 单模版

<!-- MarkdownTOC -->

- 去除默认方向键
- fn+左ctrl 复合功能切换
- fn+右shift+右ctrl 锁定ctrl
- fn+win 锁定win
- 如何确定现在键盘处于什么状态

<!-- /MarkdownTOC -->

## 去除默认方向键
> [下载固件-GANSS ALT61（单模版）20171111--新增方向键锁定解除](http://www.ganss.cn/index.php?catid=15)
> fn + 右shift
> 效果： 
1. 去除默认方向键
2. f11, f12 上移
> 再次按 fn + 右shift 会恢复 默认方向键

## fn+左ctrl 复合功能切换
> 默认： 1 -> 1， a -> a, [ -> [, - -> -, j -> j
> 第一次： 所有符合功能键第二功能键切换为激活状态， 1 -> f1， a -> a, [ -> [, - -> f11, j -> home
> 第二次： Y/U/I/H/J/K/N/M/<，这9个键恢复主功能，其他复合功能键仍为复合功能；1 -> f1， a -> a, [ -> [, - -> f11, j -> j
> 第三次： 所有复合功能恢复主功能

## fn+右shift+右ctrl 锁定ctrl
> fn+右shift+右ctrl 锁定ctrl
> fn+右ctrl 解除锁定ctrl

## fn+win 锁定win
> fn+win 锁定 win 键功能，解锁再次按 fn+win

## 如何确定现在键盘处于什么状态
> 按 向上键（/？） 如果是向上键，则需要 fn+右shift 切换
> 按 - 键如果全屏，则为第一或第二次复合功能键，按 j 如果跳到行首或者页首，则为第一次复合功能键，如果按 j 还是 j 则第二次复合功能键，需要按 fn+左ctrl 切换;
> 按 a 全选，则锁定了 ctrl，需要按一次 fn+右ctrl 切换锁定；
> win+1 没效果， win键锁定， fn+win 解除锁定
