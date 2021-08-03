# svn

<!-- MarkdownTOC -->

- SVN Checkout 问题 The XML response contains invalid XML
- [What, on the earth, is Property Modified?](#duplicate)
- SVN Mergeinfo properties on paths other than the working copy root
- tortoise svn always merging 45 extra files

<!-- /MarkdownTOC -->

## SVN Checkout 问题 The XML response contains invalid XML
> 原因：svn路径里面有“不可描述”的字符，我checkout的使用，用的是同事发来的地址，放到浏览器打开后，从浏览器地址栏复制的。这样是不行的。
> 正确的地址：
> https://svn.XXX.com:444/svn/xxx
> 输入浏览器后的坑爹地址：
> https://svn.XXX.com:444/!/%23xxx
> 解决：用正确的svn路径（废话）

## What, on the earth, is Property Modified? [duplicate]
> You don't want to stop "Property Modified" from happening. If you do a "diff" of your tree and double-click on each file that is listed as "Property Modified", you should see the details about the metadata properties that were changed. When you do a merge, the mergeinfo property gets added to files and folders so that Subversion can keep track of which revisions were merged into which copy and at what time. Without this information, merging and viewing the history of branched/merged files would be extremely difficult.
>> Why doesn't Subversion just handle the metadata in the background. Why does the client have to manually commit this metadata? I agree that this is extremely annoying and distracting. Modify 1 file and then have to commit multiple other unrelated metadata changes? Absurd.
>> It's definitely not ideal. Automatic merge tracking wasn't initially part of Subversion. When it was added later, it was done in a way that was very visible to the user (I believe this was necessary for backwards-compatibility reasons). The current version of Subversion - which was released after this question was asked - has cleaned this up dramatically and you should no longer see this large cascade of metadata changes.

## SVN Mergeinfo properties on paths other than the working copy root
> Subversion 1.5.x adds a lot of svn:mergeinfo properties, even on files/folders which you think have nothing to do with the merge. But Subversion still uses those to reduce the merge time for subsequent merges.
If you don't like those, you can safely remove those modified/added svn:mergeinfo properties from all files/folders which were not part of the merge (leave it on the working copy root and the files/folders that got changes from the merge).
Subversion 1.6 will have those svn:mergeinfo properties reduced a lot if everything goes as planned with the 1.6 release.
> If you don't like those, you can safely remove those modified/added svn:mergeinfo properties from all files/folders which were not part of the merge (leave it on the working copy root and the files/folders that got changes from the merge).
> Subversion 1.6 will have those svn:mergeinfo properties reduced a lot if everything goes as planned with the 1.6 release.

## tortoise svn always merging 45 extra files
> They're probably mergeinfo properties. With version 1.5 of SVN, it was quite aggressive with setting the mergeinfo property, and as you merge, those properties get updated - requiring a commit to them.
> The answer is to delete the mergeinfo property from them. Also upgrade to version 1.6 which has better mergeinfo support (i.e. it writes less of these properties).
> I should say that these file will have no visible changes if you look at the differences. Obviously, if their contents are changed, then what the changes are may give you a clue (e.g. is an automated tool writing extra comments, modifying the layout or adding lines to the top or bottom).
