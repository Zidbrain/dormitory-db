﻿// Licence file C:\Users\Zid\Documents\ReversePOCO.txt not found.
// Please obtain your licence file at www.ReversePOCO.co.uk, and place it in your documents folder shown above.
// Defaulting to Trial version.
// <auto-generated>
// ReSharper disable All

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database
{
    #region Database context interface

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public interface IDormitoriesContext : IDisposable
    {
        DbSet<SwitchboardItem> SwitchboardItems { get; set; } // Switchboard Items
        DbSet<Гости> Гости { get; set; } // Гости
        DbSet<Группыпользователей> Группыпользователей { get; set; } // Группы пользователей
        DbSet<Дежурства> Дежурства { get; set; } // Дежурства
        DbSet<Комнаты> Комнаты { get; set; } // Комнаты
        DbSet<Проживания> Проживания { get; set; } // Проживания
        DbSet<Студенты> Студенты { get; set; } // Студенты
        DbSet<Этажи> Этажи { get; set; } // Этажи

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        DatabaseFacade Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

    #endregion

    #region Database context

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public class DormitoriesContext : DbContext, IDormitoriesContext
    {
        public DormitoriesContext()
        {
        }

        public DormitoriesContext(DbContextOptions<DormitoriesContext> options)
            : base(options)
        {
        }

        public DbSet<SwitchboardItem> SwitchboardItems { get; set; } // Switchboard Items
        public DbSet<Гости> Гости { get; set; } // Гости
        public DbSet<Группыпользователей> Группыпользователей { get; set; } // Группы пользователей
        public DbSet<Дежурства> Дежурства { get; set; } // Дежурства
        public DbSet<Комнаты> Комнаты { get; set; } // Комнаты
        public DbSet<Проживания> Проживания { get; set; } // Проживания
        public DbSet<Студенты> Студенты { get; set; } // Студенты
        public DbSet<Этажи> Этажи { get; set; } // Этажи

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(@"Data Source=ZID-PC\SQLEXPRESS;Integrated Security=True;Initial Catalog=Dormitories;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SwitchboardItemConfiguration());
            modelBuilder.ApplyConfiguration(new ГостиConfiguration());
            modelBuilder.ApplyConfiguration(new ГруппыпользователейConfiguration());
            modelBuilder.ApplyConfiguration(new ДежурстваConfiguration());
            modelBuilder.ApplyConfiguration(new КомнатыConfiguration());
            modelBuilder.ApplyConfiguration(new ПроживанияConfiguration());
            modelBuilder.ApplyConfiguration(new СтудентыConfiguration());
            modelBuilder.ApplyConfiguration(new ЭтажиConfiguration());
        }

    }

    #endregion

    #region Database context factory

    public class DormitoriesContextFactory : IDesignTimeDbContextFactory<DormitoriesContext>
    {
        public DormitoriesContext CreateDbContext(string[] args)
        {
            return new DormitoriesContext();
        }
    }

    #endregion

    #region Fake Database context

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public class FakeDormitoriesContext : IDormitoriesContext
    {
        public DbSet<SwitchboardItem> SwitchboardItems { get; set; } // Switchboard Items
        public DbSet<Гости> Гости { get; set; } // Гости
        public DbSet<Группыпользователей> Группыпользователей { get; set; } // Группы пользователей
        public DbSet<Дежурства> Дежурства { get; set; } // Дежурства
        public DbSet<Комнаты> Комнаты { get; set; } // Комнаты
        public DbSet<Проживания> Проживания { get; set; } // Проживания
        public DbSet<Студенты> Студенты { get; set; } // Студенты
        public DbSet<Этажи> Этажи { get; set; } // Этажи

        public FakeDormitoriesContext()
        {
            _database = null;

            SwitchboardItems = new FakeDbSet<SwitchboardItem>("SwitchboardId", "ItemNumber");
            Гости = new FakeDbSet<Гости>("Id");
            Группыпользователей = new FakeDbSet<Группыпользователей>("Id");
            Дежурства = new FakeDbSet<Дежурства>("Id");
            Комнаты = new FakeDbSet<Комнаты>("Номеркомнаты");
            Проживания = new FakeDbSet<Проживания>("СтудентId");
            Студенты = new FakeDbSet<Студенты>("СтудентId");
            Этажи = new FakeDbSet<Этажи>("ЭтажId");

        }

        public int SaveChangesCount { get; private set; }
        public virtual int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public virtual int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return SaveChanges();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }
        public virtual Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(x => 1, acceptAllChangesOnSuccess, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private DatabaseFacade _database;
        public DatabaseFacade Database { get { return _database; } }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region Fake DbSet

    // ************************************************************************
    // Fake DbSet
    // Implementing Find:
    //      The Find method is difficult to implement in a generic fashion. If
    //      you need to test code that makes use of the Find method it is
    //      easiest to create a test DbSet for each of the entity types that
    //      need to support find. You can then write logic to find that
    //      particular type of entity, as shown below:
    //      public class FakeBlogDbSet : FakeDbSet<Blog>
    //      {
    //          public override Blog Find(params object[] keyValues)
    //          {
    //              var id = (int) keyValues.Single();
    //              return this.SingleOrDefault(b => b.BlogId == id);
    //          }
    //      }
    //      Read more about it here: https://msdn.microsoft.com/en-us/data/dn314431.aspx
    public class FakeDbSet<TEntity> : DbSet<TEntity>, IQueryable<TEntity>, IAsyncEnumerable<TEntity>, IListSource where TEntity : class
    {
        private readonly PropertyInfo[] _primaryKeys;
        private readonly ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _primaryKeys = null;
            _data        = new ObservableCollection<TEntity>();
            _query       = _data.AsQueryable();
        }

        public FakeDbSet(params string[] primaryKeys)
        {
            _primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            _data        = new ObservableCollection<TEntity>();
            _query       = _data.AsQueryable();
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (_primaryKeys == null)
                throw new ArgumentException("No primary keys defined");
            if (keyValues.Length != _primaryKeys.Length)
                throw new ArgumentException("Incorrect number of keys passed to Find method");

            var keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => _primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }

        public override ValueTask<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return new ValueTask<TEntity>(Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken));
        }

        public override ValueTask<TEntity> FindAsync(params object[] keyValues)
        {
            return new ValueTask<TEntity>(Task<TEntity>.Factory.StartNew(() => Find(keyValues)));
        }

        IAsyncEnumerator<TEntity> IAsyncEnumerable<TEntity>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAsyncEnumerator(cancellationToken);
        }

        public override EntityEntry<TEntity> Add(TEntity entity)
        {
            _data.Add(entity);
            return null;
        }

        public override void AddRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            foreach (var entity in entities.ToList())
                _data.Add(entity);
        }

        public override void AddRange(IEnumerable<TEntity> entities)
        {
            AddRange(entities.ToArray());
        }

        public override Task AddRangeAsync(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            return Task.Factory.StartNew(() => AddRange(entities));
        }

        public override void AttachRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            AddRange(entities);
        }

        public override void RemoveRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            foreach (var entity in entities.ToList())
                _data.Remove(entity);
        }

        public override void RemoveRange(IEnumerable<TEntity> entities)
        {
            RemoveRange(entities.ToArray());
        }

        public override void UpdateRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            RemoveRange(entities);
            AddRange(entities);
        }

        public IList GetList()
        {
            return _data;
        }

        IList IListSource.GetList()
        {
            return _data;
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
        {
            return new FakeDbAsyncEnumerator<TEntity>(this.AsEnumerable().GetEnumerator());
        }

    }

    public class FakeDbAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public FakeDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var m = expression as MethodCallExpression;
            if (m != null)
            {
                var resultType = m.Method.ReturnType; // it should be IQueryable<T>
                var tElement = resultType.GetGenericArguments()[0];
                var queryType = typeof(FakeDbAsyncEnumerable<>).MakeGenericType(tElement);
                return (IQueryable) Activator.CreateInstance(queryType, expression);
            }
            return new FakeDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            var queryType = typeof(FakeDbAsyncEnumerable<>).MakeGenericType(typeof(TElement));
            return (IQueryable<TElement>) Activator.CreateInstance(queryType, expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = new CancellationToken())
        {
            return _inner.Execute<TResult>(expression);
        }
    }

    public class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        public FakeDbAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAsyncEnumerator(cancellationToken);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.AsEnumerable().GetEnumerator();
        }
    }

    public class FakeDbAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public FakeDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public T Current
        {
            get { return _inner.Current; }
        }
        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(_inner.MoveNext());
        }

        public ValueTask DisposeAsync()
        {
            _inner.Dispose();
            return new ValueTask(Task.CompletedTask);
        }
    }

    #endregion

    #region POCO classes

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // Switchboard Items
    /// <summary>
    /// Общежитие.[Switchboard Items]
    /// </summary>
    public class SwitchboardItem
    {
        /// <summary>
        /// Общежитие.[Switchboard Items].[SwitchboardID]
        /// </summary>
        public int SwitchboardId { get; set; } // SwitchboardID (Primary key)

        /// <summary>
        /// Общежитие.[Switchboard Items].[ItemNumber]
        /// </summary>
        public short ItemNumber { get; set; } // ItemNumber (Primary key)

        /// <summary>
        /// Общежитие.[Switchboard Items].[ItemText]
        /// </summary>
        public string ItemText { get; set; } // ItemText (length: 255)

        /// <summary>
        /// Общежитие.[Switchboard Items].[Command]
        /// </summary>
        public short? Command { get; set; } // Command

        /// <summary>
        /// Общежитие.[Switchboard Items].[Argument]
        /// </summary>
        public string Argument { get; set; } // Argument (length: 255)

        public SwitchboardItem()
        {
            ItemNumber = 0;
        }
    }

    // Гости
    /// <summary>
    /// Общежитие.[Гости]
    /// </summary>
    public class Гости
    {
        /// <summary>
        /// Общежитие.[Гости].[ID]
        /// </summary>
        public int Id { get; set; } // ID (Primary key)

        /// <summary>
        /// Общежитие.[Гости].[Фамилия]
        /// </summary>
        public string Фамилия { get; set; } // Фамилия (length: 15)

        /// <summary>
        /// Общежитие.[Гости].[Имя]
        /// </summary>
        public string Имя { get; set; } // Имя (length: 15)

        /// <summary>
        /// Общежитие.[Гости].[Отчество]
        /// </summary>
        public string Отчество { get; set; } // Отчество (length: 15)

        /// <summary>
        /// Общежитие.[Гости].[Телефон]
        /// </summary>
        public string Телефон { get; set; } // Телефон (length: 255)

        /// <summary>
        /// Общежитие.[Гости].[К Кому]
        /// </summary>
        public int? Ккому { get; set; } // К Кому

        /// <summary>
        /// Общежитие.[Гости].[Дата посещения]
        /// </summary>
        public DateTime? Датапосещения { get; set; } // Дата посещения

        // Foreign keys

        /// <summary>
        /// Parent Студенты pointed by [Гости].([Ккому]) (Гости$СтудентыГости)
        /// </summary>
        public virtual Студенты Студенты { get; set; } // Гости$СтудентыГости
    }

    // Группы пользователей
    /// <summary>
    /// Общежитие.[Группы пользователей]
    /// </summary>
    public class Группыпользователей
    {
        /// <summary>
        /// Общежитие.[Группы пользователей].[ID]
        /// </summary>
        public int Id { get; set; } // ID (Primary key)

        /// <summary>
        /// Общежитие.[Группы пользователей].[Group]
        /// </summary>
        public string Group { get; set; } // Group (length: 255)

        /// <summary>
        /// Общежитие.[Группы пользователей].[Pass]
        /// </summary>
        public string Pass { get; set; } // Pass (length: 255)
    }

    // Дежурства
    /// <summary>
    /// Общежитие.[Дежурства]
    /// </summary>
    public class Дежурства
    {
        /// <summary>
        /// Общежитие.[Дежурства].[ID]
        /// </summary>
        public int Id { get; set; } // ID (Primary key)

        /// <summary>
        /// Общежитие.[Дежурства].[Студент_ID]
        /// </summary>
        public int? СтудентId { get; set; } // Студент_ID

        /// <summary>
        /// Общежитие.[Дежурства].[Выполнено]
        /// </summary>
        public bool? Выполнено { get; set; } // Выполнено

        /// <summary>
        /// Общежитие.[Дежурства].[Дата]
        /// </summary>
        public DateTime? Дата { get; set; } // Дата

        // Foreign keys

        /// <summary>
        /// Parent Студенты pointed by [Дежурства].([СтудентId]) (Дежурства$СтудентыДежурства)
        /// </summary>
        public virtual Студенты Студенты { get; set; } // Дежурства$СтудентыДежурства

        public Дежурства()
        {
            Выполнено = false;
        }
    }

    // Комнаты
    /// <summary>
    /// Общежитие.[Комнаты]
    /// </summary>
    public class Комнаты
    {
        /// <summary>
        /// Общежитие.[Комнаты].[Номер комнаты]
        /// </summary>
        public int Номеркомнаты { get; set; } // Номер комнаты (Primary key)

        /// <summary>
        /// Общежитие.[Комнаты].[Количество мест]
        /// </summary>
        public byte? Количествомест { get; set; } // Количество мест

        /// <summary>
        /// Общежитие.[Комнаты].[Этаж_ID]
        /// </summary>
        public int? ЭтажId { get; set; } // Этаж_ID

        // Reverse navigation

        /// <summary>
        /// Child Проживания where [Проживания].[Комната_ID] point to this entity (Проживания$КомнатыПроживания)
        /// </summary>
        public virtual ICollection<Проживания> Проживания { get; set; } // Проживания.Проживания$КомнатыПроживания

        // Foreign keys

        /// <summary>
        /// Parent Этажи pointed by [Комнаты].([ЭтажId]) (Комнаты$ЭтажКомната)
        /// </summary>
        public virtual Этажи Этажи { get; set; } // Комнаты$ЭтажКомната

        public Комнаты()
        {
            Количествомест = 0;
            Проживания = new List<Проживания>();
        }
    }

    // Проживания
    /// <summary>
    /// Общежитие.[Проживания]
    /// </summary>
    public class Проживания
    {
        [Key]
        /// <summary>
        /// Общежитие.[Проживания].[Студент_ID]
        /// </summary>
        public int СтудентId { get; set; } // Студент_ID (Primary key)

        /// <summary>
        /// Общежитие.[Проживания].[Комната_ID]
        /// </summary>
        public int? КомнатаId { get; set; } // Комната_ID

        /// <summary>
        /// Общежитие.[Проживания].[Заселение]
        /// </summary>
        public DateTime? Заселение { get; set; } // Заселение

        /// <summary>
        /// Общежитие.[Проживания].[Выселение]
        /// </summary>
        public DateTime? Выселение { get; set; } // Выселение

        /// <summary>
        /// Общежитие.[Проживания].[Плата за месяц]
        /// </summary>
        public decimal? Платазамесяц { get; set; } // Плата за месяц

        /// <summary>
        /// Общежитие.[Проживания].[Оплачено]
        /// </summary>
        public bool? Оплачено { get; set; } // Оплачено

        // Reverse navigation

        /// <summary>
        /// Parent (One-to-One) Проживания pointed by [Студенты].[Студент_ID] (Студенты$ПроживанияСтуденты)
        /// </summary>
        public virtual Студенты Студенты { get; set; } // Студенты.Студенты$ПроживанияСтуденты

        // Foreign keys

        /// <summary>
        /// Parent Комнаты pointed by [Проживания].([КомнатаId]) (Проживания$КомнатыПроживания)
        /// </summary>
        public virtual Комнаты Комнаты { get; set; } // Проживания$КомнатыПроживания

        public Проживания()
        {
            Платазамесяц = 0m;
            Оплачено = false;
        }
    }

    // Студенты
    /// <summary>
    /// Общежитие.[Студенты]
    /// </summary>
    public class Студенты
    {
        [Key]
        /// <summary>
        /// Общежитие.[Студенты].[Студент_ID]
        /// </summary>
        public int СтудентId { get; set; } // Студент_ID (Primary key)

        /// <summary>
        /// Общежитие.[Студенты].[Фамилия]
        /// </summary>
        public string Фамилия { get; set; } // Фамилия (length: 20)

        /// <summary>
        /// Общежитие.[Студенты].[Имя]
        /// </summary>
        public string Имя { get; set; } // Имя (length: 20)

        /// <summary>
        /// Общежитие.[Студенты].[Отчетство]
        /// </summary>
        public string Отчетство { get; set; } // Отчетство (length: 20)

        /// <summary>
        /// Общежитие.[Студенты].[Номер Группы]
        /// </summary>
        public string Номергруппы { get; set; } // Номер Группы (length: 10)

        /// <summary>
        /// Общежитие.[Студенты].[Пол]
        /// </summary>
        public int? Пол { get; set; } // Пол

        /// <summary>
        /// Общежитие.[Студенты].[Льготы]
        /// </summary>
        public string Льготы { get; set; } // Льготы (length: 255)

        /// <summary>
        /// Общежитие.[Студенты].[Телефон]
        /// </summary>
        public string Телефон { get; set; } // Телефон (length: 255)

        /// <summary>
        /// Общежитие.[Студенты].[Паспорт]
        /// </summary>
        public string Паспорт { get; set; } // Паспорт (length: 255)

        // Reverse navigation

        /// <summary>
        /// Child Гости where [Гости].[К Кому] point to this entity (Гости$СтудентыГости)
        /// </summary>
        public virtual ICollection<Гости> Гости { get; set; } // Гости.Гости$СтудентыГости

        /// <summary>
        /// Child Дежурства where [Дежурства].[Студент_ID] point to this entity (Дежурства$СтудентыДежурства)
        /// </summary>
        public virtual ICollection<Дежурства> Дежурства { get; set; } // Дежурства.Дежурства$СтудентыДежурства

        // Foreign keys
        [ForeignKey("СтудентId")]
        /// <summary>
        /// Parent Проживания pointed by [Студенты].([СтудентId]) (Студенты$ПроживанияСтуденты)
        /// </summary>
        public virtual Проживания Проживания { get; set; } // Студенты$ПроживанияСтуденты

        public Студенты()
        {
            Гости = new List<Гости>();
            Дежурства = new List<Дежурства>();
        }
    }

    // Этажи
    /// <summary>
    /// Общежитие.[Этажи]
    /// </summary>
    public class Этажи
    {
        /// <summary>
        /// Общежитие.[Этажи].[Этаж_ID]
        /// </summary>
        public int ЭтажId { get; set; } // Этаж_ID (Primary key)

        /// <summary>
        /// Общежитие.[Этажи].[Наличие кухни]
        /// </summary>
        public bool? Наличиекухни { get; set; } // Наличие кухни

        /// <summary>
        /// Общежитие.[Этажи].[Наличие душа]
        /// </summary>
        public bool? Наличиедуша { get; set; } // Наличие душа

        // Reverse navigation

        /// <summary>
        /// Child Комнаты where [Комнаты].[Этаж_ID] point to this entity (Комнаты$ЭтажКомната)
        /// </summary>
        public virtual ICollection<Комнаты> Комнаты { get; set; } // Комнаты.Комнаты$ЭтажКомната

        public Этажи()
        {
            Наличиекухни = false;
            Наличиедуша = false;
            Комнаты = new List<Комнаты>();
        }
    }


    #endregion

    #region POCO Configuration

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // Switchboard Items
    public class SwitchboardItemConfiguration : IEntityTypeConfiguration<SwitchboardItem>
    {
        public void Configure(EntityTypeBuilder<SwitchboardItem> builder)
        {
            builder.ToTable("Switchboard Items", "dbo");
            builder.HasKey(x => new { x.SwitchboardId, x.ItemNumber }).HasName("Switchboard Items$PrimaryKey").IsClustered();

            builder.Property(x => x.SwitchboardId).HasColumnName(@"SwitchboardID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.ItemNumber).HasColumnName(@"ItemNumber").HasColumnType("smallint").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.ItemText).HasColumnName(@"ItemText").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.Command).HasColumnName(@"Command").HasColumnType("smallint").IsRequired(false);
            builder.Property(x => x.Argument).HasColumnName(@"Argument").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
        }
    }

    // Гости
    public class ГостиConfiguration : IEntityTypeConfiguration<Гости>
    {
        public void Configure(EntityTypeBuilder<Гости> builder)
        {
            builder.ToTable("Гости", "dbo");
            builder.HasKey(x => x.Id).HasName("Гости$PrimaryKey").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Фамилия).HasColumnName(@"Фамилия").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Имя).HasColumnName(@"Имя").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Отчество).HasColumnName(@"Отчество").HasColumnType("nvarchar(15)").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Телефон).HasColumnName(@"Телефон").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.Ккому).HasColumnName(@"К Кому").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Датапосещения).HasColumnName(@"Дата посещения").HasColumnType("datetime2").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Студенты).WithMany(b => b.Гости).HasForeignKey(c => c.Ккому).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Гости$СтудентыГости");
        }
    }

    // Группы пользователей
    public class ГруппыпользователейConfiguration : IEntityTypeConfiguration<Группыпользователей>
    {
        public void Configure(EntityTypeBuilder<Группыпользователей> builder)
        {
            builder.ToTable("Группы пользователей", "dbo");
            builder.HasKey(x => x.Id).HasName("Группы пользователей$PrimaryKey").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Group).HasColumnName(@"Group").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.Pass).HasColumnName(@"Pass").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
        }
    }

    // Дежурства
    public class ДежурстваConfiguration : IEntityTypeConfiguration<Дежурства>
    {
        public void Configure(EntityTypeBuilder<Дежурства> builder)
        {
            builder.ToTable("Дежурства", "dbo");
            builder.HasKey(x => x.Id).HasName("Дежурства$PrimaryKey").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.СтудентId).HasColumnName(@"Студент_ID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Выполнено).HasColumnName(@"Выполнено").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.Дата).HasColumnName(@"Дата").HasColumnType("datetime2").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Студенты).WithMany(b => b.Дежурства).HasForeignKey(c => c.СтудентId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Дежурства$СтудентыДежурства");
        }
    }

    // Комнаты
    public class КомнатыConfiguration : IEntityTypeConfiguration<Комнаты>
    {
        public void Configure(EntityTypeBuilder<Комнаты> builder)
        {
            builder.ToTable("Комнаты", "dbo");
            builder.HasKey(x => x.Номеркомнаты).HasName("Комнаты$PrimaryKey").IsClustered();

            builder.Property(x => x.Номеркомнаты).HasColumnName(@"Номер комнаты").HasColumnType("int").IsRequired().ValueGeneratedNever(); //.UseIdentityColumn();
            builder.Property(x => x.Количествомест).HasColumnName(@"Количество мест").HasColumnType("tinyint").IsRequired(false);
            builder.Property(x => x.ЭтажId).HasColumnName(@"Этаж_ID").HasColumnType("int").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Этажи).WithMany(b => b.Комнаты).HasForeignKey(c => c.ЭтажId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Комнаты$ЭтажКомната");

            builder.HasIndex(x => x.ЭтажId).HasDatabaseName("Комнаты$КомнатаЭтаж_ID");
        }
    }

    // Проживания
    public class ПроживанияConfiguration : IEntityTypeConfiguration<Проживания>
    {
        public void Configure(EntityTypeBuilder<Проживания> builder)
        {
            builder.ToTable("Проживания", "dbo");
            builder.HasKey(x => x.СтудентId).HasName("Проживания$PrimaryKey").IsClustered();

            builder.Property(x => x.СтудентId).HasColumnName(@"Студент_ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.КомнатаId).HasColumnName(@"Комната_ID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Заселение).HasColumnName(@"Заселение").HasColumnType("datetime2").IsRequired(false);
            builder.Property(x => x.Выселение).HasColumnName(@"Выселение").HasColumnType("datetime2").IsRequired(false);
            builder.Property(x => x.Платазамесяц).HasColumnName(@"Плата за месяц").HasColumnType("money").IsRequired(false);
            builder.Property(x => x.Оплачено).HasColumnName(@"Оплачено").HasColumnType("bit").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Комнаты).WithMany(b => b.Проживания).HasForeignKey(c => c.КомнатаId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Проживания$КомнатыПроживания");
        }
    }

    // Студенты
    public class СтудентыConfiguration : IEntityTypeConfiguration<Студенты>
    {
        public void Configure(EntityTypeBuilder<Студенты> builder)
        {
            builder.ToTable("Студенты", "dbo");
            builder.HasKey(x => x.СтудентId).HasName("Студенты$PrimaryKey").IsClustered();

            builder.Property(x => x.СтудентId).HasColumnName(@"Студент_ID").HasColumnType("int").IsRequired().ValueGeneratedNever()/*.UseIdentityColumn()*/;
            builder.Property(x => x.Фамилия).HasColumnName(@"Фамилия").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Имя).HasColumnName(@"Имя").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Отчетство).HasColumnName(@"Отчетство").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Номергруппы).HasColumnName(@"Номер Группы").HasColumnType("nvarchar(10)").IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.Пол).HasColumnName(@"Пол").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Льготы).HasColumnName(@"Льготы").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.Телефон).HasColumnName(@"Телефон").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.Паспорт).HasColumnName(@"Паспорт").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);

            // Foreign keys
            builder.HasOne(a => a.Проживания).WithOne(b => b.Студенты).HasForeignKey<Студенты>(c => c.СтудентId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Студенты$ПроживанияСтуденты");

            builder.HasIndex(x => x.СтудентId).HasDatabaseName("Студенты$ПроживанияСтуденты").IsUnique();
        }
    }

    // Этажи
    public class ЭтажиConfiguration : IEntityTypeConfiguration<Этажи>
    {
        public void Configure(EntityTypeBuilder<Этажи> builder)
        {
            builder.ToTable("Этажи", "dbo");
            builder.HasKey(x => x.ЭтажId).HasName("Этажи$PrimaryKey").IsClustered();

            builder.Property(x => x.ЭтажId).HasColumnName(@"Этаж_ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Наличиекухни).HasColumnName(@"Наличие кухни").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.Наличиедуша).HasColumnName(@"Наличие душа").HasColumnType("bit").IsRequired(false);
        }
    }


    #endregion

}
// </auto-generated>
