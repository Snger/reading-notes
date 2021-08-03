# trading view

## 快速选出
````js
function n(t, e) {
    var i, o, n, r = t.length;
    if (0 === r)
        return -1;
    if (isNaN(e))
        throw Error("Key is NaN");
    for (i = 0,
    o = r - 1,
    n = s((i + o) / 2); ; ) {
        if (t[n] > e) {
            if ((o = n - 1) < i)
                return n
        } else if (i = n + 1,
        o < i)
            return n < r - 1 ? n + 1 : -1;
        n = s((i + o) / 2)
    }
}
let utc_offset_array = [
  -2177481943000,
  -933494400000,
  -923130000000,
  -908784000000,
  -891594000000,
  515520000000,
  527007600000,
  545155200000,
  558457200000,
  576604800000,
  589906800000,
  608659200000,
  621961200000,
  640108800000,
  653410800000,
  671558400000,
  684860400000,
  1924992000000
];
let timestamp = 1521504000000;
n(utc_offset_array, timestamp);
````