# gitlab

<!-- MarkdownTOC -->

- Setting Our Own Variables
- gitlab 404 group not found
- Namespaced path encoding

<!-- /MarkdownTOC -->

## Setting Our Own Variables
> [link](https://ryanstutorials.net/bash-scripting-tutorial/bash-variables.php#quotes)
> As well as variables that are preset by the system, we may also set our own variables. This can be useful for keeping track of results of commands and being able to refer to and process them later.
> There are a few ways in which variables may be set (such as part of the execution of a command) but the basic form follows this pattern:
`variable=value`

## gitlab 404 group not found
> 
````bash
GROUP_NAME="$1"
GROUP_PATH="${GROUP_NAME/-/}"
````

## Namespaced path encoding
> The ID or URL-encoded path of the group owned by the authenticated user
> If using namespaced API calls, make sure that the NAMESPACE/PROJECT_PATH is URL-encoded.
> For example, / is represented by %2F:
GET /api/v4/projects/diaspora%2Fdiaspora
> Note: A project’s path is not necessarily the same as its name. A project’s path can found in the project’s URL or in the project’s settings under General > Advanced > Change path.
