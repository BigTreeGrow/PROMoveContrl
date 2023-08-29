using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardContrl
{
    public class conti
    {
        /// <summary>
        /// 连续插补结构体
        /// </summary>
        public struct contiSt
        {
            /// <summary>
            /// 插补拐角使能
            /// </summary>
            public ushort contiBlendEnable;
            /// <summary>
            /// 前瞻段数
            /// </summary>
            public int lookaheadNum;
            /// <summary>
            /// 前瞻精度误差
            /// </summary>
            public double pathError;
            /// <summary>
            /// 前瞻加速度
            /// </summary>
            public double lookaheadAcc;
            /// <summary>
            /// 直线插补最大速度
            /// </summary>
            public double contiMaxSpeed;
            /// <summary>
            /// 直线插补最小速度
            /// </summary>
            public double contiMinSpeed;
            /// <summary>
            /// 直线插补停止速度
            /// </summary>
            public double contiStopSpeed;
            /// <summary>
            /// 直线插补加速时间
            /// </summary>
            public double contiAccTime;
            /// <summary>
            /// 直线插补减速时间  
            /// </summary>
            public double contiDecTime;
            /// <summary>
            /// 直线插补平滑曲线 0-1000ms 0代表梯形
            /// </summary>
            public double contiSpars;
        }
    }
}
