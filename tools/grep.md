# grep

<!-- MarkdownTOC -->

- How To Grep Multiple Strings, Patterns or Regex in A Text File In Linux?
- How can I exclude one word with grep?
- grep统计某个单词的个数

<!-- /MarkdownTOC -->

## How To Grep Multiple Strings, Patterns or Regex in A Text File In Linux?
> `grep` provides a lot of features to match strings, patterns or regex in a given text. One of the most used feature is to match two or more, multiple string, patterns or regex. In this tutorial we will look different examples about these features. If you need more general tutorial about regex please look following article.
> ### Grep -E or Egrep
Before starting examples we look different commands which provides same functionality. We can use grep  command with -E  option or egrep command which is the alias of the grep -E . They are both the same. In this tutorial we will follow grep -E. -E means extended grep which will enable extended regular expression features to use.
> ### Match Multiple Strings
We will start with the simplest example. We will match given multiple strings inside a given text. In this example we will use a file named data.txt as a text. The matching strings will be ismail  and ali .
`$ grep -E "ismail|ali" data.txt`
> ### Match Multiple Pattern or Regex
Now we want to use multiple regular expression or pattern in our match term. We can specify standard regular expression with the same way. We will change some letters with . in this example.
`$ grep -E "is.ail|al." data.txt`
> ### Match IP Address or Domain Name
Now we will look useful example which provides IP address or domain names. This may be a regular operation while searching in log files. We will use `[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}`  as IP Address regex and  `\.[a-z]{1,20}\.[a-z]+` as domain name regex.
`$ grep -E "([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3})|(\.[a-z]{1,20}\.[a-z]+)" data.txt`
> ### Match In Multiple Files
We have also the ability to search and match in multiple files. We can use bash glob feature for this. We will use * for the all names and .txt to match text files in this example.
`$ grep -E "ismail|ali" *.txt`

## How can I exclude one word with grep?
> If your grep supports Perl regular expression with -P option you can do (if bash; if tcsh you'll need to escape the !):
`grep -P '(?!.*unwanted_word)keyword' file`
Demo:
````bash
$ cat file
foo1
foo2
foo3
foo4
bar
baz
Let us now list all foo except foo3
$ grep -P '(?!.*foo3)foo' file
foo1
foo2
foo4
$ 
````

## grep统计某个单词的个数
> 统计 / 的数量， -c参数只能统计行。如果要统计个数， 可以再来个重定向；
`echo 'frontend/leke-webapp/fe-homework/mobile/hk-homework-detail' | grep -o / | grep -c /`

