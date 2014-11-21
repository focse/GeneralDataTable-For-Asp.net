using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTableSource
{
    /// <summary>
    /// 愤怒的TryCatch 定义接口，规范所有输出Table 
    /// 标准型
    /// </summary>
    public interface ITable
    {
        string title();
        string databond();
        string page();
        string tables();
    }
}
