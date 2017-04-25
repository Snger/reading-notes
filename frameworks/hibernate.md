## (NHibernate.Criterion.Expression)Creates a new Criteria for the entity class with a specific alias
> session.CreateCriteria<TransactionGoodsPO>("goods");

## (NHibernate.Criterion.Expression)Set a limit upon the number of objects to be retrieved
> session.CreateCriteria<TransactionGoodsPO>("goods").SetMaxResults(limit).List<TransactionGoodsPO>();

## (NHibernate.Criterion.Expression)Apply a "like" constraint to the project
> session.CreateCriteria<TransactionGoodsPO>("goods").Add(Restrictions.Like("goods.GoodsCode", goodsCode, MatchMode.Anywhere)).List<TransactionGoodsPO>();

