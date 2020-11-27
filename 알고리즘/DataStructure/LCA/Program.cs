using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCA
{
   // 최소 공통 조상?

   // 목적 : 두 노드 간의 거리를 구하는데 유용하게 사용되는데,
   // 두 노드 간의 거리는 (루트와 노드1 간의 거리) + (루트와 노드2 간의 거리) - (2*루트와 LCA 간의 거리)
   
      // 두 노드의 경로를 구한 후 앞에서부터 동일한 경로을 알아내면 최소 공통 조상이된다.
      // 이러한 방식은 보통 트리를 두번 순회하여야 하고, 별도의 경로 저장 공간이 필요하는 단점이 있음
   class Program
   {
      static void Main(string[] args)
      {
      }
   }
}
