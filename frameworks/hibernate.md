## (NHibernate.Criterion.Expression)Creates a new Criteria for the entity class with a specific alias
> session.CreateCriteria<TransactionGoodsPO>("goods");

## (NHibernate.Criterion.Expression)Set a limit upon the number of objects to be retrieved
> session.CreateCriteria<TransactionGoodsPO>("goods").SetMaxResults(limit).List<TransactionGoodsPO>();

## (NHibernate.Criterion.Expression)Apply a "like" constraint to the project
> session.CreateCriteria<TransactionGoodsPO>("goods").Add(Restrictions.Like("goods.GoodsCode", goodsCode, MatchMode.Anywhere)).List<TransactionGoodsPO>();

## Basic property and class mappings
1. A typical Hibernate property mapping defines a JavaBeans property name, a data- base column name, and the name of a Hibernate type. It maps a JavaBean style property to a table column. The basic declaration provides many variations and optional settings. It’s often possible to omit the type name. So, if description is a property of (Java) type java.lang.String, Hibernate will use the Hibernate type string by default (we discuss the Hibernate type system in chapter 6). 
2. Hibernate uses reflection to determine the Java type of the property. 
3. You can even omit the column name if it’s the same as the property name, ignor- ing case. (This is one of the sensible defaults we mentioned earlier.)
