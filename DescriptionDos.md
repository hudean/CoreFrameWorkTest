# ���Ŀ��ʹ���ֲ�

- [���Ŀ��ʹ���ֲ�](#���Ŀ��ʹ���ֲ�)
  - [�������](#�������)
  - [���ʹ������](#���ʹ������)
  - [ʹ�÷�ʽ](#ʹ�÷�ʽ)
    - [ģ�黯](#ģ�黯)
      - [ģ�黯](#ģ�黯-1)
      - [elasticSearch](#elasticsearch)
      - [eventbus](#eventbus)
        - [RabbitMq](#rabbitmq)
      - [entityFraworkCore](#entityfraworkcore)
    - [ֱ������](#ֱ������)
      - [elasticSearch](#elasticsearch-1)
      - [eventbus](#eventbus-1)
        - [RabbitMq](#rabbitmq-1)
      - [entityFraworkCore](#entityfraworkcore-1)

## �������

�ÿ���ṩ��һЩ�������ܵ�ʵ�֣�����ElasticSearch��Eventbus�ȡ�

## ���ʹ������

�ÿ���ṩ������ʹ�÷�ʽ��һ��ֱ������������һ������ģ�黯�����������ҽ��������ַ�ʽ��ʹ��

## ʹ�÷�ʽ

### ģ�黯

#### ģ�黯

```c#
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServiceCollection<StartupModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.BuildApplicationBuilder();
        }
    }
```

```c#
    public class StartupModule : CoreModuleBase
    {
        public StartupModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public override void ConfigureServices(ServiceCollectionContext context)
        {    
        }

        public override void Configure(ApplicationBuilderContext context)
        {   
        }
    }
```

#### elasticSearch

```c#
 [DependsOn(      
        typeof(CoreElasticSearchModule))]
    public class StartupModule : CoreModuleBase
    {
        public StartupModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public override void ConfigureServices(ServiceCollectionContext context)
        {    
         //��ʽһ
          context.Services.Configure<ElasticClientFactoryOptions>(Configuration.GetSection("ElasticClient"));
          
         //��ʽ��
          context.Services.AddElasticClientFactory("�Զ�������"��options=>{
           options.UserName="";
           options.PassWord="";
           options.Urls=new string[]{};
           options.DefaultIndex="";
           options.ElasticClientLifeTime=TimeSpan.FromHours(24)//Ĭ�ϲ�С��1Сʱ
          });
        }
    }
```

```c#
  public interface IDemoEsRepository:IElasticSearchRepositories<�Զ�������>
  {
     //�Զ����ѯ����
  }

  public class DemoEsRepository : ElasticSearchRepositories<�Զ�������>, IDemoEsRepository
  {
      public ComputeApplyEsRepository(IElasticClientFactory elasticClientFactory)
      : base(elasticClientFactory,elasticClientName:"���������ע�������ƥ��   ")
      {
      }
  }
```
```json
��appsetting.json����ElasticClient

 "ElasticClient": {
    "UserName": "elastic",
    "PassWord": "septnet",
    "Urls":[""],
    "DefaultIndex":"elastic_search_default_index"
  },
```

#### eventbus

##### RabbitMq

```c#
[DependsOn(      
         typeof(CoreEventBusRabbitMqModule),
         typeof(CoreEventBusSqlServerModule))]
    public class StartupModule : CoreModuleBase
    {
        public StartupModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
      
        public override void ConfigureServices(ServiceCollectionContext context)
        {    
          context.Services.Configure<EventBusRabbitMqOptions>(options =>
            {
               //���÷������������ɲ�����
                options.AddPublishConfigure();
                //���ö��Ľ������Ͷ��У��ɲ�����
                options.AddSubscribeConfigures();
            });
                                  
           //�����ڱ�����Ϣ��洢event��������      
           context.Services.Configure<EventBusSqlServerOptions>(options =>
            {
                //����Connection�����룩
                options.ConnectionString = Configuration.GetConnectionString("customer");
            });
            
            //���÷����Ƕ��ķ��������������´���
            context.Services.TryRegistrarMessageHandlers(new[] { typeof(StartupModule).Assembly });
            context.Services.Configure<EventBusOptions>(options =>
            {
                options.AutoRegistrarHandlersAssemblies = new[] { typeof(StartupModule).Assembly };
            });          
        }
    }
```
```json
2.��appsetting.json����Rabbitmq
 "RabbitMq": {
    "Connection": {
      "hostName": "127.0.0.1",
      "userName": "guest",
      "password": "guest",
      "port": "-1",
      "virtualHost": "/"
    }
  }
```

#### entityFraworkCore

```c#
    [DependsOn(typeof(CoreEfCoreModule))]
    public class StartupModule : CoreModuleBase
    {
        public StartupModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public override void ConfigureServices(ServiceCollectionContext context)
        {
            context.Services.AddControllers();
                    
            context.Services.AddDbContext<CustomerDbContext>(options =>
             {
                 options.UseSqlServer(Configuration.GetConnectionString("Customer"));
             });
        }
    }
```

���������뷢�������¼����Զ����DbContext��̳�CoreDbContext��������Լ���eventbus���磺

```
[DependsOn(      
        typeof(CoreEventBusRabbitMqModule),
         typeof(CoreEventBusSqlServerModule))]
```



### ֱ������

#### elasticSearch

```c#
   public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
 //��ʽһ
         services.Configure<ElasticClientFactoryOptions>(Configuration.GetSection("ElasticClient"));
         Services.AddElasticClientFactory();
 //��ʽ��
         services.AddElasticClientFactory("�Զ�������"��options=>{
           options.UserName="";
           options.PassWord="";
           options.Urls=new string[]{};
           options.DefaultIndex="";
           options.ElasticClientLifeTime=TimeSpan.FromHours(24)//Ĭ�ϲ�С��1Сʱ
          });
                  
        }   
    }
```

#### eventbus

##### RabbitMq

```c#
public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           //���Ƕ��ķ�������Զ�ɨ����򼯣����Զ�ע��Handler��ServiceCollection��       
           services.AddEventBus(options => 
                    {
                        //���Ƕ��ķ�������Զ�ɨ�����
                        options.AutoRegistrarHandlersAssemblies = new[] { typeof(Startup).Assembly }
                    })
                   .AddRabbitMq(options =>
                    {
                        //������Ϣ��Ӧ��Exchange���������ã���ʹ��Ĭ�ϵģ�
                        options.AddPublishConfigure(configureOptions =>
                        {
                            configureOptions.ExchangeName = RabbitMqConst.DefaultExchangeName;
                        });
                    })
                    .AddSqlServer(options =>
                     {
                         options.ConnectionString = Configuration.GetConnectionString("customer");
                     });
            services.Configure<RabbitMqOptions>(Configuration.GetSection("RabbitMq"));
            services.AddRabbitMq();
        }      
    }
```

#### entityFraworkCore

```c#
   public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
          services.AddEntityFrameworkRepository();
        }   
    }
```
