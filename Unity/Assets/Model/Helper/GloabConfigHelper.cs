using System;

namespace ETModel
{
    public static class GloabConfigHelper
    {
        public static ControllerType controllerType = ControllerType.PC;

        /// <summary>
        /// 每秒发包次数，但是不会超过帧数
        /// </summary>
        public static float tick = 1.0f / 32.0f;
    }

    public enum ControllerType
    {
        PC,
        Mobile
    }
}