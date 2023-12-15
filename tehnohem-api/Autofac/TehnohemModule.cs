using Autofac;
using tehnohem_api.Excel;
using tehnohem_api.Services.Implementation;
using tehnohem_api.Services.Interface;
using tehnohem_api.UnitOfWork.Implementation;
using tehnohem_api.UnitOfWork.Interface;

namespace tehnohem_api.Autofac
{
    public class TehnohemModule : Module
    {
        public TehnohemModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<tehnohem_api.UnitOfWork.Implementation.UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //========Services===========
            builder.RegisterType<RawService>().As<IRawService>();
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<InvoicesService>().As<IInvoicesService>();
            builder.RegisterType<PaymentService>().As<IPaymentService>();
            builder.RegisterType<ExcelService>().As<IExcelService>();
        }
    }
}
