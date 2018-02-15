# DataGrip

<!-- MarkdownTOC -->

- How To Export/Import A Data Source From DataGrip?
- Moving your data sources onto another computer
- An open source alternative to datagrip?
- Open a SQL file as a Console in DataGrip

<!-- /MarkdownTOC -->

## How To Export/Import A Data Source From DataGrip?
> It is possible! You need to share a project with your friend — all you do in DataGrip is in the context of a project. If you did not create a new one, everything is under the default project.
> File - open Recent - manage projects - go to project path
> paste project config
> In my case, I wanted to move project level data sources from phpStorm to DataGrip and this worked: `mv my-project/.idea/dataSources dataSources.* ~/Library/Preferences/DataGrip2017.2/projects/default/.idea/`

## Moving your data sources onto another computer
> [link](https://www.jetbrains.com/help/datagrip/moving-your-data-sources-onto-another-computer.html)
> - About projects
Your data source settings are stored in projects. When you start DataGrip for the first time, the project called default is created, and you work with that project unless you create another one (File | New | Project).
> - Finding out the project locations
> Each project is stored in its own folder. The folders have the same names as your projects (e.g. default).
> To find out where the folder of interest is located, select File | Open Recent | Manage Projects. As a result, your recently used projects and their locations are shown. ~ in the popup means your home directory.
> - Default project locations
> If you haven't found your project yet, here are the default project locations:
````
Windows: <your-home-dir>\.DataGrip<version>\config\projects
macOS: <your-home-dir>/Library/Preferences/DataGrip<version>/projects
Linux: <your-home-dir>/.DataGrip<version>/projects
````
> - Making your data sources available on another computer
> Transfer the project folder of interest onto the destination computer.
On the destination computer, open the folder in DataGrip: start DataGrip, select File | Open, and then select the project folder.

## An open source alternative to datagrip?
> Have you looked at dbeaver? dbeaver does everything I need! thanks!

## Open a SQL file as a Console in DataGrip
> Attach Directory in the Files tool window,
> Select the necessary SQL file in the Files tool window, or open the file in the editor.
> Select Run "<file_name>" from the context menu.(right click in console window)
> In the Choose Data Source pop-up, click the data source to which the script should be applied.
If you want to run the script for more than one data source, select the data sources of interest in the pop-up and press Enter.

