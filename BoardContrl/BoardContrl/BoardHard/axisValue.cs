using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardContrl
{
    /*
    类库名称:雷赛轴参数定义
    开发时间:2020.12.8
    修改时间:2020.12.8
    类库说明:用结构体已包含雷赛轴所需要的参数,调用是直接调用axis创建一个泛型list则可
     */
    public class axisValue
    {
        
        /// <summary>
        /// 轴结构体
        /// </summary>
        public struct axis
        {

            /// <summary>
            /// 轴名称
            /// </summary>
            public ushort axisName;
            /// <summary>
            /// 控制卡编号
            /// </summary>
            public ushort cardNo;
            /// <summary>
            /// 轴号
            /// </summary>
            public ushort cardAxis;
            /// <summary>
            /// 输出模式
            /// "0:脉冲+方向 PULS低 DIR高", "1:脉冲+方向 PULS高 DIR高", "2:脉冲+方向 PULS低 DIR低",
            /// "3:脉冲+方向 PULS高 DIR低", "4:CW/CCW 低电平" , "5:CW/CCW 高电平"
            /// </summary>
            public ushort outMode;
            /// <summary>
            /// 原点信号
            ///  "0:常开", "1:常闭"
            /// </summary>
            public ushort orgLogic;
            /// <summary>
            /// 回零方向
            /// "0:负向", "1:正向" 
            /// </summary>
            public ushort homeDir;
            /// <summary>
            /// 回零速度模式 
            /// "0:低速回零", "1:高速回零"
            /// </summary>
            public ushort velMode;
            /// <summary>
            /// 回原点模式
            /// "0:一次回零", "1:一次回零加回找", "2:二次回零", "3：原点加同向EZ", "4:单独记一个EZ" ,
            /// "5:原点加反向EZ","6:原点锁存","7:原点锁存加同向EZ","8:单独记一个EZ锁存","9:原点锁存加反向EZ"
            /// </summary>
            public ushort orgMode;
            /// <summary>
            /// 限位信号使能状态
            /// "0:禁用","1:使能"
            /// </summary>
            public ushort elEnable;
            /// <summary>
            /// 限位信号有效电平
            /// "0:正负限位常开", "1:正负限位常闭", "2:正常开 负常闭", "3:正常闭 负常开"
            /// </summary>
            public ushort elLogic;
            /// <summary>
            /// 限位制动方式
            /// "0:正负限位禁止", "1:正负限位允许", "2:正限位禁止,负限位允许", "3:负限位禁止,正限位允许"
            /// </summary>
            public ushort elMode;
            /// <summary>
            /// 软限位使能状态
            /// "0:禁用", "1:使能"
            /// </summary>
            public ushort slEnable;
            /// <summary>
            /// 软限位计数器选择
            /// "0:指令计数器", "1:编码器计数器"
            /// </summary>
            public ushort slSourceSel;
            /// <summary>
            /// 软限位停止方式
            /// "0:立刻停止", "1:减速停止"
            /// </summary>
            public ushort slAction;
            /// <summary>
            /// 负限位设置
            /// </summary>
            public double Nlimit;
            /// <summary>
            /// 正限位设置
            /// </summary>
            public double Plimit;
            /// <summary>
            /// 单轴起始速度
            /// </summary>
            public double oneMinSpeed;
            /// <summary>
            /// 单轴最大速度
            /// </summary>
            public double oneMaxSpeed;
            /// <summary>
            /// 单轴加速时间
            /// </summary>
            public double oneAccTime;
            /// <summary>
            /// 单轴减速时间
            /// </summary>
            public double oneDecTime;
            /// <summary>
            /// 单轴停止速度
            /// </summary>
            public double oneStopSpeed;
            /// <summary>
            /// 一圈脉冲
            /// </summary>
            public int roundPuls;
            /// <summary>
            /// 一圈距离
            /// </summary>
            public int roundDistance;
            /// <summary>
            /// 轴类型
            /// "0:直线轴", "1:旋转轴"
            /// </summary>
            public ushort axisType;
            /// <summary>
            /// 轴精度(0.1 0.01 0.001)
            /// </summary>
            public double accuary;
            /// <summary>
            /// 持续运动速度
            /// </summary>
            public double oneVelSpeed;
            /// <summary>
            /// S曲线时间(0-0.5S)
            /// </summary>
            public double Stime;
            /// <summary>
            /// 单轴停止时间
            /// </summary>
            public double oneStopTime;
            /// <summary>
            /// 锁存源
            ///  "0:锁存指令位置", "1:锁存编码位置"
            /// </summary>
            public ushort EZ_count;
            /// <summary>
            /// 回原点速度
            /// </summary>
            public double homeSpeed;
            /// <summary>
            /// 回原点反找速度
            /// </summary>
            public double homeBackSpeed;
            /// <summary>
            /// 原点偏移
            /// </summary>
            public double orgOffset;
        }

        #region 参数枚举
        /// <summary>
        /// 输出模式枚举
        /// </summary>
        public enum OutMode
        {
            #region 输出模式
            /// <summary>
            /// 0:脉冲方向 pulse低电平有效 dir高电平正
            /// </summary>
            pluseAndSign_1,
            /// <summary>
            /// 1:脉冲方向 pulse高电平有效 dir高电平正
            /// </summary>
            pluseAndSign_2,
            /// <summary>
            /// 2:脉冲方向 pulse低电平有效 dir低电平正
            /// </summary>
            pluseAndSign_3,
            /// <summary>
            ///3:脉冲方向 pulse高电平有效 dir低电平正 
            /// </summary>
            pluseAndSign_4,
            /// <summary>
            /// 4:双脉冲 pulse脉冲低电平有效 dir高电平正/ pulse高电平正 dir脉冲低电平有效 
            /// </summary>
            doublePluse_1,
            /// <summary>
            /// 5:双脉冲 pulse脉冲高电平有效 dir低电平正/ pulse低电平正 dir脉冲高电平有效
            /// </summary>
            doublePluse_2
            #endregion
        }

        /// <summary>
        /// 原点信号枚举
        /// </summary>
        public enum OrgLogic
        {
            #region 原点信号
            /// <summary>
            /// 0:低电平
            /// </summary>
            lowLogic,
            /// <summary>
            /// 1:高电平
            /// </summary>
            higeLogic
            #endregion
        }

        /// <summary>
        /// 回零方向枚举
        /// </summary>
        public enum HomeDir
        {
            #region 回零方向
            /// <summary>
            /// 0:负向
            /// </summary>
            Negative,
            /// <summary>
            /// 1:正向
            /// </summary>
            Positive
            #endregion
        }

        /// <summary>
        /// 回零速度模式枚举
        /// </summary>
        public enum VelMode
        {
            #region 回零速度模式 
            /// <summary>
            /// 0：低速回零，本指令前面的 dmc_set_profile 函数设置的起始速度运行
            /// </summary>
            lowSpeed,
            /// <summary>
            /// 1：高速回零，本指令前面的 dmc_set_profile 函数设置的最大速度运行 
            /// </summary>
            highSpeed
            #endregion
        }

        /// <summary>
        /// 回原点模式枚举
        /// </summary>
        public enum OrgMode
        {
            #region 回原点模式
            /// <summary>
            /// 0: 一次回零
            /// </summary>
            mode0,
            /// <summary>
            /// 1: 一次回零加回找 
            /// </summary>
            mode1,
            /// <summary>
            /// 2: 二次回零 
            /// </summary>
            mode2,
            /// <summary>
            /// 3：原点加同向EZ
            /// </summary>
            mode3,
            /// <summary>
            /// 4: 单独记一个EZ
            /// </summary>
            mode4,
            /// <summary>
            /// 5: 原点加反向EZ 
            /// </summary>
            mode5,
            /// <summary>
            /// 6: 原点锁存 
            /// </summary>
            mode6,
            /// <summary>
            /// 7: 原点锁存加同向EZ
            /// </summary>
            mode7,
            /// <summary>
            /// 8: 单独记一个EZ锁存
            /// </summary>
            mode8,
            /// <summary>
            /// 9: 原点锁存加反向EZ 
            /// </summary>
            mode9
            #endregion
        }

        /// <summary>
        /// 限位信号使能状态枚举
        /// </summary>
        public enum ElEnable
        {
            #region 限位信号使能状态
            /// <summary>
            /// 0:正负限位禁止
            /// </summary>
            _P_And_N_Prohibit,
            /// <summary>
            /// 1:正负限位允许 
            /// </summary>
            _P_And_N_Enable,
            /// <summary>
            /// 2:正限位禁止,负限位允许 
            /// </summary>
            _P_ProhibitOnly,
            /// <summary>
            /// 3:负限位禁止,正限位允许 
            /// </summary>
            _N_ProhibitOnly
            #endregion
        }

        /// <summary>
        /// 限位信号有效电平枚举
        /// </summary>
        public enum ElLogic
        {
            #region 限位信号有效电平
            /// <summary>
            /// 正负限位低电平有效
            /// </summary>
            _P_And_N_Low,
            /// <summary>
            /// 正负限位高电平有效
            /// </summary>
            _P_And_N_High,
            /// <summary>
            /// 正低有效 负高有效
            /// </summary>
            _P_LowAnd_N_High,
            /// <summary>
            /// 正高有效 负低有效
            /// </summary>
            _P_HighAnd_N_Low
            #endregion
        }

        /// <summary>
        /// 限位制动方式枚举
        /// </summary>
        public enum ElMode
        {
            #region 限位制动方式
            /// <summary>
            /// 正负限位立刻停止
            /// </summary>
            _P_And_N_StopAtOnce,
            /// <summary>
            /// 正负限位减速停止
            /// </summary>
            _P_And_N_StopSlow,
            /// <summary>
            /// 正限位立刻停止,负限位减速停止
            /// </summary>
            _P_StopAtOnce,
            /// <summary>
            /// 正限位减速停止,负限位减速停止
            /// </summary>
            _N_StopAtOnce
            #endregion
        }

        /// <summary>
        /// 软限位使能状态枚举
        /// </summary>
        public enum SlEnable
        {
            #region 软限位使能状态
            /// <summary>
            /// 禁止
            /// </summary>
            prohibit,
            /// <summary>
            /// 允许
            /// </summary>
            allow
            #endregion
        }

        /// <summary>
        /// 计数器选择枚举
        /// </summary>
        public enum SlSourceSel
        {
            #region 计数器选择
            /// <summary>
            /// 指令计数器
            /// </summary>
            instructCode,
            /// <summary>
            /// 编码器计数器
            /// </summary>
            encodeCode
            #endregion
        }

        /// <summary>
        /// 软限位停止方式枚举
        /// </summary>
        public enum slAction
        {
            #region 软限位停止方式
            /// <summary>
            /// 立刻停止
            /// </summary>
            atOnce,
            /// <summary>
            /// 减速停止
            /// </summary>
            slowDown
            #endregion
        }

        /// <summary>
        /// 单轴连续运动方向枚举
        /// </summary>
        public enum VmoveDir
        {
            #region 单轴连续运动方向
            /// <summary>
            /// 反方向
            /// </summary>
            _N_Dir,
            /// <summary>
            /// 正方向
            /// </summary>
            _P_Dir
            #endregion
        }

        /// <summary>
        /// 运动模式枚举
        /// </summary>
        public enum PosiMode
        {
            #region 单轴运动模式
            /// <summary>
            /// 相对模式
            /// </summary>
            Relative,
            /// <summary>
            /// 绝对模式
            /// </summary>
            Absolutely
            #endregion

        }

        /// <summary>
        /// 轴类型枚举
        /// </summary>
        public enum AxisType
        {
            #region 轴类型
            /// <summary>
            /// 直线轴
            /// </summary>
            straightLine,
            /// <summary>
            /// 旋转轴
            /// </summary>
            rotation
            #endregion
        }

        /// <summary>
        /// 轴类型枚举
        /// </summary>
        public enum ServoLogic
        {
            #region 伺服逻辑
            /// <summary>
            /// 低电平
            /// </summary>
            lowLogic,
            /// <summary>
            /// 高电平
            /// </summary>
            highLogic
            #endregion
        }

        #endregion
        
    }
}
