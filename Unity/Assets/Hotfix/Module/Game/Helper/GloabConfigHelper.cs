using System;
using ETModel;

namespace ETHotfix
{
    public static class GloabConfigHelper
    {
        public static ControllerType controllerType = ControllerType.PC;
    }

    public enum ControllerType
    {
        PC,
        Mobile
    }
}