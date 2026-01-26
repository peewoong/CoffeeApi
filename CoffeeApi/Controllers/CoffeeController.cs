using Microsoft.AspNetCore.Mvc;
using CoffeeApi.Models;

namespace CoffeeApi.Controllers
{
    // 이 컨트롤러의 주소는 https://localhost:7282/api/coffee 가 됩니다.
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        // [GET] 요청이 들어오면 실행되는 함수
        [HttpGet]
        public List<Coffee> GetCoffeeMenu()
        {
            List<Coffee> coffeeList = new List<Coffee>
            {
                new Coffee("아메리카노", 4500),
                new Coffee("카페라떼", 5000),
                new Coffee("바닐라라떼", 5500)
            };

            return coffeeList;
            
            /*
            // 간단한 메뉴 리스트를 만들어 반환
            List<string> menu = new List<string>
            {
                "에스프레소",
                "아메리카노",
                "카페라떼",
                "바닐라라떼 (추천)"
            };

            return menu;
            */
        }

        // 특정 순번(index)의 커피 정보를 반환하는 함수
        // 주소 예시 : api/coffee/0 또는 api/coffee/1
        [HttpGet("{id}")]
        public Coffee GetCoffeeById(int id) {             // 간단한 예시로, 고정된 커피 데이터를 반환
            List<Coffee> coffeeList = new List<Coffee>
            {
                new Coffee("아메리카노", 4500),
                new Coffee("카페라떼", 5000),
                new Coffee("바닐라라떼", 5500)
            };

            // 만약 리스트 범위 밖의 숫자를 요청하면 에러 발생 가능, 안전장치 설치
            if (id < 0 || id >= coffeeList.Count)
            {
                return null; // 또는 적절한 오류 처리
            }

            return coffeeList[id];
        }
    }
}
