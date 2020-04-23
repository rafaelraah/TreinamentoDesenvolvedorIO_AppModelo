using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Services
{
    public class OperacaoService
    {
        public OperacaoService(IOperacaoTransient OperacaoTransient,
                               IOperacaoScoped OperacaoScoped,
                               IOperacaoSingleton OperacaoSingleton,
                               IOperacaoSingletonInstance OperacaoSingletonInstance)
        {
            Transient = OperacaoTransient;
            Scoped = OperacaoScoped;
            Singleton = OperacaoSingleton;
            SingletonInstance = OperacaoSingletonInstance;
        }

        public IOperacaoTransient Transient { get; }
        public IOperacaoScoped Scoped { get; }
        public IOperacaoSingleton Singleton { get; }
        public IOperacaoSingletonInstance SingletonInstance { get; }

    }

    public class Operacao : IOperacaoTransient, IOperacaoScoped, IOperacaoSingleton, IOperacaoSingletonInstance
    {
        public Operacao() : this(Guid.NewGuid())
        {

        }

        public Operacao(Guid id)
        {
            this.OperacaoID = id;
        }

        public Guid OperacaoID { get; private set; }
    }

    public interface IOperacao
    {
        Guid OperacaoID { get; }
    }

    public interface IOperacaoTransient : IOperacao
    {

    }

    public interface IOperacaoScoped : IOperacao
    {

    }

    public interface IOperacaoSingleton : IOperacao
    {

    }

    public interface IOperacaoSingletonInstance : IOperacao
    {

    }
}
