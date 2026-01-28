using Microsoft.AspNetCore.Mvc;
using CoffeeApi.Models;

namespace CoffeeApi.Controllers
{
    // 이 컨트롤러의 주소는 https://localhost:7282/api/coffee 가 됩니다.
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        // 의존성 주입(DI) : 서버가 알아서 DB 관리자들을 이 컨트롤러에 넣어줍니다
        public CoffeeController(AppDbContext context)
        {
            _context = context;
        }

        /*
        // static을 붙여서 서버가 켜져 있는 동안 리스트를 딱 하나만 유지
        private static List<Coffee> coffeeList = new List<Coffee>
            {
                new Coffee("아메리카노", 4500),
                new Coffee("카페라떼", 5000),
                new Coffee("바닐라라떼", 5500)
            };
        */

        // [GET] 요청이 들어오면 실행되는 함수
        // 1. 전체 조회 (DB에서 가져오기)
        [HttpGet]
        public List<Coffee> GetCoffeeMenu()
        {
            return _context.Coffee.ToList();
            //return coffeeList; // 공통 리스트 반환
        }

        // 특정 순번(index)의 커피 정보를 반환하는 함수
        // 주소 예시 : api/coffee/0 또는 api/coffee/1
        [HttpGet("{id}")]
        public Coffee GetCoffeeById(int id) {             // 간단한 예시로, 고정된 커피 데이터를 반환
            var coffee = _context.Coffee.Find(id);

            // 만약 리스트 범위 밖의 숫자를 요청하면 에러 발생 가능, 안전장치 설치
            if (id < 0 || id >= _context.Coffee.ToList().Count || coffee == null)
            {
                return null; // 또는 적절한 오류 처리
            }

            return coffee;
        }

        // 새로운 커피 메뉴를 추가하는 함수
        [HttpPost]
        public string AddCoffee(Coffee newCoffee)
        {
            _context.Coffee.Add(newCoffee);
            _context.SaveChanges(); // 이 코드를 써야 DB 파일에 실제로 저장됨
            // _context.Coffee.ToList().Add(newCoffee);
            return $"{newCoffee.Name}이(가) DB에 저장되었습니다!";
        }

        // 특정 번호의 커피를 삭제하는 기능
        [HttpDelete("{id}")]
        public string DeleteCoffee(int id)
        {
            var coffee = _context.Coffee.Find(id);
            if (coffee == null) return "삭제할 커피가 없습니다.";

            _context.Coffee.Remove(coffee);
            _context.SaveChanges(); // save
            return $"{coffee.Name} 메뉴가 삭제되었습니다.";

            /*
            if(id < 0 || id >= _context.Coffee.ToList().Count)
            {
                return "삭제할 커피가 없습니다.";
            }

            Coffee removedCoffee = _context.Coffee.ToList()[id];
            _context.Coffee.ToList().RemoveAt(id);

            return $"{removedCoffee.Name} 메뉴가 삭제되었습니다.";
            */
        }

        // 특정 번호의 커피 정보를 수정하는 기능
        [HttpPut("{id}")]
        public string UpdateCoffee(int id, Coffee updatedCoffee)
        {
            var existingCoffee = _context.Coffee.Find(id);
            if (existingCoffee == null) return "수정할 커피가 없습니다.";

            existingCoffee.Name = updatedCoffee.Name;
            existingCoffee.Price = updatedCoffee.Price;

            _context.SaveChanges(); // save
            return $"{id}번 메뉴가 수정되었습니다.";

            /*
            // 1. 해당 번호가 리스트에 있는지 확인 (안전장치)
            if(id < 0 || id >= _context.Coffee.ToList().Count)
            {
                return "수정할 커피 번호가 잘못되었습니다.";
            }

            // 2. 기존 데이터를 새 데이터로 교체
            // 여기서는 리스트의 해당 칸에 새로운 객체를 덮어씌운다.
            _context.Coffee.ToList()[id] = updatedCoffee;

            return $"{id}번 메뉴가 {updatedCoffee.Name} (으)로 수정되었습니다.";
            */
        }
    }
}
