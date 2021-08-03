# DBFlow

## FlowManager.init(this)
> [github - FlowManage](https://github.com/Raizlabs/DBFlow/blob/master/dbflow/src/main/java/com/raizlabs/android/dbflow/config/FlowManager.java)
````java
public class FlowManager {
	private static final String DEFAULT_DATABASE_HOLDER_NAME = "GeneratedDatabaseHolder";
	public static void init(@NonNull Context context) {
        init(new FlowConfig.Builder(context).build());
    }
    public static void init(@NonNull FlowConfig flowConfig) {
        FlowManager.config = flowConfig;
        try {
            //noinspection unchecked
            Class<? extends DatabaseHolder> defaultHolderClass = (Class<? extends DatabaseHolder>) Class.forName(DEFAULT_DATABASE_HOLDER_CLASSNAME);
            loadDatabaseHolder(defaultHolderClass);
        } catch (ModuleNotFoundException e) {
            FlowLog.log(FlowLog.Level.W, e.getMessage());
        } catch (ClassNotFoundException e) {
            FlowLog.log(FlowLog.Level.W, "Could not find the default GeneratedDatabaseHolder");
        }
        if (!flowConfig.databaseHolders().isEmpty()) {
            for (Class<? extends DatabaseHolder> holder : flowConfig.databaseHolders()) {
                loadDatabaseHolder(holder);
            }
        }
        if (flowConfig.openDatabasesOnInit()) {
            List<DatabaseDefinition> databaseDefinitions = globalDatabaseHolder.getDatabaseDefinitions();
            for (DatabaseDefinition databaseDefinition : databaseDefinitions) {
                // triggers open, create, migrations.
                databaseDefinition.getWritableDatabase();
            }
        }
    }
     /**
     * @return The database holder, creating if necessary using reflection.
     */
    protected static void loadDatabaseHolder(Class<? extends DatabaseHolder> holderClass) {
        if (loadedModules.contains(holderClass)) {
            return;
        }
        try {
            // Load the database holder, and add it to the global collection.
            DatabaseHolder dbHolder = holderClass.newInstance();
            if (dbHolder != null) {
                globalDatabaseHolder.add(dbHolder);
                // Cache the holder for future reference.
                loadedModules.add(holderClass);
            }
        } catch (Throwable e) {
            e.printStackTrace();
            throw new ModuleNotFoundException("Cannot load " + holderClass, e);
        }
    }
}
````
