// namespace ate.Definitions
// {
//     public interface ICommon
//     {
//         string Name { get; set; }
//         string Guid { get; set; }
//         string NameSpace { get; set; }

//         ICommon Parent { get; }



//     }

//     public static class Common
//     {
//         public static void Autofill(this ICommon Common)
//         {
//             if (Common.NameSpace == "")
//             {
//                 if (Common.Parent != null)
//                 {
//                     Common.NameSpace = Common.Parent.NameSpace + "." + Common.Name;
//                 }
//                 else
//                 {
//                     Common.NameSpace = Common.Name;
//                 }
//             }
//         }
//     }
// }