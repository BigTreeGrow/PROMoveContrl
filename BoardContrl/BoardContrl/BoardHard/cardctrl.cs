using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardContrl
{
    public class cardCtl : LTDMC
    {
        /*类库名称:雷赛板卡控制(总线卡)
        *开始时间:2023.08.29
        *修改时间:2023.08.29
        *类库说明:
        */
        #region 私有变量

        private errorCode errorCode = new errorCode();//定义错误代码类

        #endregion

        /// <summary>
        /// 设定脉冲当量(轴结构体)
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        public void dmcSetEquiv(axisValue.axis axisStruct)
        {

            double equiv = Convert.ToDouble(axisStruct.roundPuls) / Convert.ToDouble(axisStruct.roundDistance);

            short error = dmc_set_equiv(axisStruct.cardNo, axisStruct.cardAxis, equiv);

            if (error != 0)
            {
                throw new Exception(string.Format("轴{0}设定脉冲当量--错误代码:{1} 内容:{2}", axisStruct.axisName, error, errorCode.errorCodeSelect(error)));
            }

        }

        /// <summary>
        /// 设置软限位信号(轴结构体)
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        public void dmcSetSoftlimit(axisValue.axis axisStruct)
        {

            double result = 0;
            if (axisStruct.axisType == (ushort)axisValue.AxisType.straightLine)
            {
                result = ((double)axisStruct.roundPuls / (double)axisStruct.roundDistance) * axisStruct.accuary;
            }

            int _longNlimit = (int)((axisStruct.Nlimit / axisStruct.accuary) * result);
            int _longPlimit = (int)((axisStruct.Plimit / axisStruct.accuary) * result);

            short error = dmc_set_softlimit_unit(axisStruct.cardNo, axisStruct.cardAxis, axisStruct.slEnable, axisStruct.slSourceSel, axisStruct.slAction, _longNlimit, _longPlimit);

            if (error != 0)
            {
                throw new Exception(string.Format("轴{0}设定软限位信号--错误代码:{1} 内容:{2}", axisStruct.axisName, error, errorCode.errorCodeSelect(error)));
            }

        }


        /// <summary>
        /// 当前轴位置读取(轴结构体)
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        /// <returns></returns>
        public double positionRead(axisValue.axis axisStruct)
        {
            //double units= Convert.ToDouble(axisStruct.roundDistance)/Convert.ToDouble(axisStruct.roundPuls);

            //double pos = (double)dmc_get_position(axisStruct.cardNo, axisStruct.cardAxis);

            //pos = pos * units;

            double pos = 0;
            dmc_get_position_unit(axisStruct.cardNo, axisStruct.cardAxis, ref pos);

            return pos;
        }

        /// <summary>
        /// 点运动(轴结构体,方向)
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        /// <param name="sign">方向</param>
        public void vMove(axisValue.axis axisStruct, ushort sign)
        {
            short error = LTDMC.dmc_set_profile_unit(axisStruct.cardNo, axisStruct.cardAxis, axisStruct.oneMinSpeed, axisStruct.oneVelSpeed, axisStruct.oneAccTime, axisStruct.oneDecTime, axisStruct.oneStopSpeed);//设置速度参数
            error = LTDMC.dmc_vmove(axisStruct.cardNo, axisStruct.cardAxis, sign);
            if (error != 0)
            {
                throw new Exception(string.Format("轴{0}持续运动--错误代码:{1} 内容:{2}", axisStruct.axisName, error, errorCode.errorCodeSelect(error)));
            }

        }


        /// <summary>
        /// 位置模式--绝对运动
        /// </summary>
        /// <param name="AxisNo"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public void Absolute_Move(axisValue.axis axisStruct, double Position)
        {
           
            short error = 0;

            LTDMC.dmc_set_profile_unit(axisStruct.cardNo, axisStruct.cardAxis, axisStruct.oneMinSpeed, axisStruct.oneVelSpeed, axisStruct.oneAccTime, axisStruct.oneDecTime, axisStruct.oneStopSpeed);//设置速度参数
            LTDMC.dmc_set_s_profile(axisStruct.cardNo, axisStruct.cardAxis, 0, axisStruct.Stime);//设置S段速度参数
            error = LTDMC.dmc_pmove_unit(axisStruct.cardNo, axisStruct.cardAxis, Position, 1);
            if (error != 0)
            {
                throw new Exception(string.Format("轴{0}绝对运动--错误代码:{1} 内容:{2}", axisStruct.axisName, error, errorCode.errorCodeSelect(error)));
            }
        }

        /// <summary>
        /// 位置模式--相对运动
        /// </summary>
        /// <param name="AxisNo"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public void Relative_Move(axisValue.axis axisStruct, double Position)
        {

            short error = 0;

            LTDMC.dmc_set_profile_unit(axisStruct.cardNo, axisStruct.cardAxis, axisStruct.oneMinSpeed, axisStruct.oneVelSpeed, axisStruct.oneAccTime, axisStruct.oneDecTime, axisStruct.oneStopSpeed);//设置速度参数
            LTDMC.dmc_set_s_profile(axisStruct.cardNo, axisStruct.cardAxis, 0, axisStruct.Stime);//设置S段速度参数
            error = LTDMC.dmc_pmove_unit(axisStruct.cardNo, axisStruct.cardAxis, Position, 0);
            if (error != 0)
            {
                throw new Exception(string.Format("轴{0}绝对运动--错误代码:{1} 内容:{2}", axisStruct.axisName, error, errorCode.errorCodeSelect(error)));
            }
        }




        /// <summary>
        /// 轴停止(轴结构体,停止模式(0:减速停止 1:紧急停止))
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        /// <param name="stopMode">停止模式</param>
        public void axisStop(axisValue.axis axisStruct, ushort stopMode)
        {
            /*
             * stopMode
             *0:减速停止 1:紧急停止
             */
            short error = LTDMC.dmc_stop(axisStruct.cardNo, axisStruct.cardAxis, stopMode);//减速停止

            speedInit(axisStruct);//初始化速度

            if (error != 0)
            {
                throw new Exception(string.Format("轴{0}停止--错误代码:{1} 内容:{2}", axisStruct.axisName, error, errorCode.errorCodeSelect(error)));
            }
        }

        /// <summary>
        /// 速度初始化(轴结构体)
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        public void speedInit(axisValue.axis axisStruct)
        {
            short error = (short)0;

            error = LTDMC.dmc_set_profile_unit(axisStruct.cardNo, axisStruct.cardAxis, axisStruct.oneMinSpeed, axisStruct.oneMaxSpeed, axisStruct.oneAccTime, axisStruct.oneDecTime, axisStruct.oneStopSpeed);//设置速度参数

            error = LTDMC.dmc_set_s_profile(axisStruct.cardNo, axisStruct.cardAxis, 0, axisStruct.Stime);//设置S段速度参数

            error = LTDMC.dmc_set_dec_stop_time(axisStruct.cardNo, axisStruct.cardAxis, axisStruct.oneStopTime); //设置减速停止时间

            if (error != 0)
            {
                throw new Exception(string.Format("轴{0}速度初始化--错误代码:{1} 内容:{2}", axisStruct.axisName, error, errorCode.errorCodeSelect(error)));
            }
        }


        /// <summary>
        /// 轴状态返回(轴结构体)
        /// 返回0：运行 1：停止
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        /// <returns></returns>
        public short axisStauts(axisValue.axis axisStruct)
        {
            return LTDMC.dmc_check_done(axisStruct.cardNo, axisStruct.cardAxis);
        }

        /// <summary>
        /// 设定轴原点位置(轴结构体,位置)
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        /// <param name="position">位置</param>
        public void setPosition(axisValue.axis axisStruct, double position)
        {
            LTDMC.dmc_set_position_unit(axisStruct.cardNo, axisStruct.cardAxis, position);
        }

        /// <summary>
        /// 单轴使能函数(轴结构体,位置)
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        /// 
        public void Axis_Enable(axisValue.axis axisStruct)
        {
            short error = (short)0;
            error =  LTDMC.nmc_set_axis_enable(axisStruct.cardNo, axisStruct.cardAxis);
            if (error != 0)
            {
                throw new Exception(string.Format("轴{0}速度初始化--错误代码:{1} 内容:{2}", axisStruct.axisName, error, errorCode.errorCodeSelect(error)));
            }
        }

        /// <summary>
        /// 清除总线故障(轴结构体,位置)
        /// </summary>
        /// <param name="axisStruct">轴结构体</param>
        /// 
        public void Ecat_Error_CLear(ushort CardNo)
        {
            LTDMC.nmc_clear_alarm_fieldbus( CardNo, 2);
        }





    }
}
