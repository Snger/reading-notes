# nginx

## How do I specify Windows file paths in nginx
> These answers must be out of date. Using nginx 1.3.8 absolute paths with forward slashes works. Backslashes seem to work, but should be doubled. If they aren't then some, such as a trailing \" are taken literally.
	````nginx
	location /static/ {
	    # alias "C:\\foo\\bar\\...\\static\\";
	    alias "C:/foo/bar/.../static/";
	    expires 90d;
	}
	````
>The quotes may not be required, but they seem like a good idea in case of embedded spaces.
>One other thing I noticed is that it is important to match the url and alias path regarding ending with a trailing slash or not--a mismatch and it doesn't work.