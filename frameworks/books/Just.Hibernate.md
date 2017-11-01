# Just Hibernate - a lightweight introduction to the hibernate framework
> OReilly.Just.Hibernate.2014.6, Second release
> by Madhusudhan Konda
> ISBN: 978-1-449-33437-6

<!-- MarkdownTOC -->

- CHAPTER 5 Associations
    - Types of associations
    - One-to-One Association
        - Using a Primary Key
        - Using a Foreign Key
    - One-to-Many \(or Many-to-One\) Association
    - Bidirectional One-to-Many Association

<!-- /MarkdownTOC -->

# CHAPTER 5 Associations
## Types of associations
````
|----------------|----------------------------|----------------------------|
|  Association   |         Definition         |          Example           |
|----------------|----------------------------|----------------------------|
| One-to-one     | Each record in one table   | A car has only one engine. |
|                | is related to exactly one  |                            |
|                | record in the second table |                            |
|                | and vice versa. The other  |                            |
|                | side could also            |                            |
|                | be a zero record.          |                            |
|----------------|----------------------------|----------------------------|
| One-to-many or | Each record in one table   | A movie has many actors    |
| many-to-one    | is related to zero or      | (one-to-many); an actor    |
|                | more recordsin the         | can act in many movies     |
|                | second table.              | (many-to-one).             |
|----------------|----------------------------|----------------------------|
| Many-to-many   | Each record in either of   | Each student can enroll in |
|                | the tables is related to   | multiple courses, and      |
|                | zero or more records       | each course can have many  |
|                | in the other table.        | students registered.       |
|----------------|----------------------------|----------------------------|
````

## One-to-One Association
### Using a Primary Key
````java
// Car class
public class Car {
    private int id;
    private String name;
    private String color;
    // car has an engine
    private Engine engine;
    ...
}
// Engine class
public class Engine {
    private int id = 0;
    private String make = null;
    private String model = null;
    private String size = null;
    // this engine is fitted to a car
    private Car car = null;
}
````
````sql
# CAR table
CREATE TABLE CAR (
    CAR_ID int(10) NOT NULL,
    NAME varchar(20) DEFAULT NULL,
    COLOR varchar(20) DEFAULT NULL,
    PRIMARY KEY (CAR_ID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ENGINE table
CREATE TABLE ENGINE (
    CAR_ID int(10) NOT NULL,
    MAKE varchar(20) DEFAULT NULL,
    MODEL varchar(20) DEFAULT NULL,
    SIZE varchar(20) DEFAULT NULL,
    PRIMARY KEY (CAR_ID),
    FOREIGN KEY (CAR_ID) REFERENCES car (CAR_ID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
````
````xml
<hibernate-mapping package="com.madhusudhan.jh.associations.one2one">
    <class name="Car" table="CAR">
        <id name="id" column="CAR_ID">
            <generator class="assigned"/>
        </id>
        <property name="name" column="NAME"/>
        <property name="color" column="COLOR"/>
        <one-to-one name="engine" class="Engine" cascade="all"/>
    </class>
</hibernate-mapping>

<hibernate-mapping package="com.madhusudhan.jh.associations.one2one">
    <class name="Engine" table="ENGINE">
        <id name="id" column="CAR_ID" >
            <generator class="foreign">
                <param name="property">car</param>
            </generator>
        </id>
        <one-to-one name="car" class="Car" constrained="true"/>
        <property name="size" column="SIZE"/>
        ...
    </class>
</hibernate-mapping>
````
### Using a Foreign Key
````mysql
CREATE TABLE CAR_V2 (
    CAR_ID int(10) NOT NULL,
    ENGINE_ID int(10) NOT NULL,
    COLOR varchar(20) DEFAULT NULL,
    NAME varchar(20) DEFAULT NULL,
    PRIMARY KEY (CAR_ID),
    CONSTRAINT FK_ENG_ID FOREIGN KEY (engine_id) REFERENCES ENGINE_v2 (ENGINE_ID)
)
CREATE TABLE ENGINE_V2 (
    ENGINE_ID int(10) NOT NULL,
    MAKE varchar(20) DEFAULT NULL,
    MODEL varchar(20) DEFAULT NULL,
    SIZE varchar(20) DEFAULT NULL,
    PRIMARY KEY (ENGINE_ID)
)
````
````xml
<hibernate-mapping package="com.madhusudhan.jh.associations.one2one">
    <!-- using foreign key -->
    <class name="Engine" table="ENGINE_V2">
        <id name="id" column="ENGINE_ID" >
            <generator class="assigned"/>
        </id>
        <property name="size" column="SIZE" />
        ...
    </class>
</hibernate-mapping>

<hibernate-mapping package="com.madhusudhan.jh.associations.one2one">
    <class name="Car" table="CAR_V2">
        <id name="id" column="CAR_ID" >
            <generator class="assigned"/>
        </id>
        <property name="name" column="NAME" />
        <property name="color" column="COLOR"/>

        <!-- the unique="true" makes this many-to-one
            relationship as one-to-one.
            This is very important setting for this strategy -->
        <many-to-one name="engine" class="Engine"
            column="engine_id"
            unique="true"
            cascade="all" />
    </class>
</hibernate-mapping>
````

## One-to-Many (or Many-to-One) Association
````java
// Actor
public class Actor {
    private int id = 0;
    private String firstName = null;
    private String lastName = null;
    private String shortName = null;
    // Setters and getters
    ...
}

public class Movie {
    private int id = 0;
    private String title = null;
    private Set<Actor> actors = null;
    public Set<Actor> getActors() {
        return actors;
    }
    public void setActors(Set<Actor> actors) {
        this.actors = actors;
    }
    ...
}
````
````mysql
// Simple and straightforward movie definition
create table movie_one2many (
    movie_id int(10) not null,
    title varchar(10) default null,
    primary key (movie_id)
)
// Note that foreign key definition
CREATE TABLE ACTOR_ONE2MANY (
    ACTOR_ID int(10) NOT NULL AUTO_INCREMENT,
    FIRST_NAME varchar(20) DEFAULT NULL,
    LAST_NAME varchar(20) DEFAULT NULL,
    SHORT_NAME varchar(20) DEFAULT NULL,
    MOVIE_ID int(10) DEFAULT NULL,
    PRIMARY KEY (ACTOR_ID),
    CONSTRAINT FK_MOV_ID FOREIGN KEY (MOVIE_ID)
    REFERENCES MOVIE_ONE2MANY (MOVIE_ID)
)
````
````xml
<hibernate-mapping package="com.madhusudhan.jh.associations.one2many">
    <class name="Actor" table="ACTOR_ONE2MANY">
        <id name="id" column="ACTOR_ID">
            <generator class="assigned"/>
        </id>
        <property name="firstName" column="FIRST_NAME" />
        ...
    </class>
</hibernate-mapping>
// Movie
<hibernate-mapping package="com.madhusudhan.jh.associations.one2many">
    <class name="Movie" table="MOVIE_ONE2MANY">
        <id name="id" column="MOVIE_ID" >
            <generator class="assigned"/>
        </id>
        <property name="title" column="TITLE" />
        <set name="actors" table="ACTOR_ONE2MANY" cascade="all">
            <key column="MOVIE_ID" not-null="true"/>
            <one-to-many class="Actor"/>
        </set>
    </class>
</hibernate-mapping>
````

## Bidirectional One-to-Many Association
````java
public class Actor {
    // We want to know the movie this actor belongs to!
    private Movie movie = null;
    ...
    public Movie getMovie() {
    return movie;
    }
    public void setMovie(Movie movie) {
        this.movie = movie;
    }
}
````
````xml
<hibernate-mapping package="com.madhusudhan.jh.associations.one2many.bi">
    <class name="Actor" table="ACTOR_ONE2MANY_BI">
        <id name="id" column="ACTOR_ID">
            <generator class="assigned"/>
        </id>
        <many-to-one name="movie" column="MOVIE_ID" class="Movie"/>
        ...
    </class>
</hibernate-mapping>
````
