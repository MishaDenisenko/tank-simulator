using System;
using UnityEngine;

namespace _Scripts.Hangar {
    public class ViewCase {

        private static ViewEnum _viewEnum = ViewEnum.SelfTanks;

        public static ViewEnum ViewEnum {
            get => _viewEnum;
            set => _viewEnum = value;
        }
    }
}