该框架开发步骤
1、首先开发CoreFrameWork.Modularity模块层
和 CoreFrameWork.Domain 领域层 （领域层暂时不要Event相关的） 最顶层

2、开发CoreFrameWork.EntityFrameWorkCore 层引用CoreFrameWork.Modularity和CoreFrameWork.Domain


3、建CoreFrameWork.EventBus层和CoreFrameWork.RabbitMQ层


4、CoreFrameWork.EventBus.SqlServer 等引用CoreFrameWork.EventBus，
CoreFrameWork.EventBus.RabbitMQ 引用CoreFrameWork.EventBus和CoreFrameWork.RabbitMQ


5、CoreFrameWork.Domain层引用CoreFrameWork.EventBus层，建立IDomainRepository接口和DomainRepository 以及聚合根AggregateRootEvent





