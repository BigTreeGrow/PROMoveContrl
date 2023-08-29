using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardContrl
{
    public class errorCode
    {
        /*类库名称:雷赛错误代码索引
         *开发时间:2020.12.8
         *修改时间:2020.12.8
         *类库说明:
         *short code=1;
         *string errorText=errorCodeSelect(code);
         */

        public string errorCodeSelect(short code)
        {
            string errorResult=string.Empty;
            switch(code)
            {
                case 0: errorResult = "成功"; break;
                case 1: errorResult = "未知错误"; break;
                case 2: errorResult = "参数错误"; break;
                case 3: errorResult = "PCI通讯超时"; break;
                case 4: errorResult = "轴正在运行"; break;
                case 6: errorResult = "连续插补错误"; break;
                case 8: errorResult = "无法连接错误"; break;
                case 9: errorResult = "卡号连接错误"; break;
                case 10: errorResult = "PCI异常,请检查槽位是否松动"; break;
                case 12: errorResult = "固件文件错误"; break;
                case 14: errorResult = "固件不匹配"; break;
                case 20: errorResult = "固件参数错误"; break;
                case 22: errorResult = "固件当前状态不允许操作"; break;
                case 24: errorResult = "固件不支持的操作"; break;
                case 25: errorResult = "密码错误"; break;
                case 26: errorResult = "密码错误输入次数受限"; break;
                case 50: errorResult = "LIST号错误"; break;
                case 51: errorResult = "LIST不在打开状态"; break;
                case 52: errorResult = "参数不在有效范围"; break;
                case 53: errorResult = "LIST已打开"; break;
                case 54: errorResult = "主要的LIST没有初始化"; break;
                case 55: errorResult = "轴数不在有效范围"; break;
                case 56: errorResult = "轴数映射表为空"; break;
                case 57: errorResult = "映射轴错误"; break;
                case 58: errorResult = "映射轴忙"; break;
                case 59: errorResult = "运动中不运行更改参数"; break;
                case 60: errorResult = "缓冲区已满"; break;
                case 61: errorResult = "半径为0或小于两点的距离的一半"; break;
                case 63: errorResult = "加减速时间为0"; break;
                case 64: errorResult = "主要的LIST没有启动"; break;
                case 81: errorResult = "BLEND模式下不支持此功能"; break;
                case 800: errorResult = "螺距补偿总点数超限,最大256"; break;
                case 801: errorResult = "螺距长度补偿小于等于零"; break;
                case 900: errorResult = "从轴已经作为主轴使用"; break;
                case 901: errorResult = "主轴已经作为从轴使用"; break;
                case 902: errorResult = "不是主从关系"; break;
                case 903: errorResult = "从轴已经被使用"; break;
                case 904: errorResult = "主从轴编码器计数模式不一致"; break;
                case 905: errorResult = "减速停止误差大于紧急停止误差"; break;
                case 906: errorResult = "从轴没有对应主轴"; break;
            }

            return errorResult;
        }
    }
}
