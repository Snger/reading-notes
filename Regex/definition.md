## Capturing group
1. Syntax: (regex)
2. Parentheses group the regex between them. They capture the text matched by the regex inside them into a numbered group that can be reused with a numbered backreference. They allow you to apply regex operators to the entire grouped regex.
3. Example: (abc){3} matches abcabcabc. First group matches abc.

## Non-capturing group
1. Syntax: (?:regex)
2. Non-capturing parentheses group the regex so you can apply regex operators, but do not capture anything.
3. Example: (?:abc){3} matches abcabcabc. No groups.

## Backreference 
1. Syntax: \1 through \9
2. Substituted with the text matched between the 1st through 9th numbered capturing group.
3. Example: (abc|def)=\1 matches abc=abc or def=def, but not abc=def or def=abc.

## Backreference 
1. Syntax: \k<1> through \k<99>
2. Substituted with the text matched between the 1st through 99th numbered capturing group.
3. Example: (abc|def)=\k<1> matches abc=abc or def=def, but not abc=def or def=abc.

## Nested backreference 
1. Syntax: Any numbered backreference
2. Backreferences can be used inside the group they reference.
3. Example: (a\1?){3} matches aaaaaa.

