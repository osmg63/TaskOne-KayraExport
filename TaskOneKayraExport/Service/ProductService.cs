using AutoMapper;
using TaskOneKayraExport.Data.Repository;
using TaskOneKayraExport.Dto;
using TaskOneKayraExport.Entity;

namespace TaskOneKayraExport.Service
{
    public class ProductService
    {
        
        private readonly ProductRepository _repository;
        private readonly IMapper _mapper;

 

        public ProductService(ProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<ProductResponseDto> Add(ProductRequestDto dto)
        {
            var result= await _repository.Add(_mapper.Map<Product>(dto));
            return _mapper.Map<ProductResponseDto>(result);
        }
        public async Task<bool> Delete(int id)
        {
            var data = await _repository.Get(x => x.Id == id);
            if (data == null) {
                throw new Exception("product not found");
                
            }
            return await _repository.Delete(data);
        }
        public async Task<List<ProductResponseDto>> GetAll()
        {
            var data = await _repository.GetAll();
            return _mapper.Map<List<ProductResponseDto>>(data);
        }
        public async Task<ProductResponseDto> GetById(int id)
        {
            var data = await _repository.Get(x => x.Id == id);
            if (data == null)
            {
                throw new Exception("product not found.");
            }

            return _mapper.Map<ProductResponseDto>(data);
        }
        public async Task<ProductResponseDto> Update(int id,ProductRequestDto dto)
        {

            var data = await _repository.Get(x => x.Id == id);


            if (data == null)
                throw new Exception("Product not found");



            _mapper.Map(dto, data);
            await _repository.SaveChangesAsync();
           
            return _mapper.Map<ProductResponseDto>(data); ;
            
        }






    }
}
