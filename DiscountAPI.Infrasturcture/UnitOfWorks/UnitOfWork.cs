using System;
using System.Threading.Tasks;
using DiscountAPI.Core.Repositories;
using DiscountAPI.Core.UnitOfWorks;
using DiscountAPI.Infrasturcture.Context;
using DiscountAPI.Infrasturcture.Repositories;

namespace DiscountAPI.Infrasturcture.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository _productRepository;
        private CustomerRepository _customerRepository;
        private DiscountRepository _discountRepository;
        private CustomerTypeRepository _customerTypeRepository;
        private InvoiceRepository _invoiceRepository;
        private InvoiceProductsRepository _invoiceProductsRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
        public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_context);
        public IDiscountRepository Discounts => _discountRepository ??= new DiscountRepository(_context);

        public ICustomerTypeRepository CustomerTypes => _customerTypeRepository ??= new CustomerTypeRepository(_context);

        public IInvoiceRepository Invoices => _invoiceRepository ??= new InvoiceRepository(_context);

        public IInvoiceProductsRepository InvoiceProducts => _invoiceProductsRepository ??= new InvoiceProductsRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}