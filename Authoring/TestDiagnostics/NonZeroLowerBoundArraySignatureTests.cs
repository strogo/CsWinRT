﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDiagnostics
{

    /* ** non-zero lowerbound array ** */

    // public property in class
    public sealed class NonZeroLowerBound_PublicProperty_Invalid
    {
        public int[] Arr
        {
            get { return (int[])Array.CreateInstance(typeof(int), new int[] { 4 }, new int[] { 1 }); }
        }

        public System.Array Arr2
        {
            get { return Array.CreateInstance(typeof(int), new int[] { 4 }, new int[] { 1 }); }
        }

        public int[] Arr3
        {
            get { return (int[])Array.CreateInstance(typeof(int), new int[] { 4 }); }
        }

        public System.Array Arr4
        {
            get { return Array.CreateInstance(typeof(int), new int[] { 4 }); }
        }
    } 

    public sealed class NonZeroLowerBound_PrivateProperty_Valid
    {
        private int[] PrivArr
        {
            get { return (int[])Array.CreateInstance(typeof(int), new int[] { 4 }, new int[] { 1 }); }
        }
        private System.Array PrivArr2
        {
            get { return Array.CreateInstance(typeof(int), new int[] { 4 }, new int[] { 1 }); }
        }
        private int[] PrivArr3
        {
            get { return (int[])Array.CreateInstance(typeof(int), new int[] { 4 }); }
        }
        private System.Array PrivArr4
        {
            get { return Array.CreateInstance(typeof(int), new int[] { 4 }); }
        }
    }

    internal sealed class NonZeroLowerBound_PrivateClass_Valid
    {
        public int[] Arr
        {
            get { return (int[])Array.CreateInstance(typeof(int), new int[] { 4 }, new int[] { 1 }); }
        }

        public System.Array Arr2
        {
            get { return Array.CreateInstance(typeof(int), new int[] { 4 }, new int[] { 1 }); }
        }

        public int[] Arr3
        {
            get { return (int[])Array.CreateInstance(typeof(int), new int[] { 4 }); }
        }
        public System.Array Arr4
        {
            get { return Array.CreateInstance(typeof(int), new int[] { 4 }); }
        }

        private int[] PrivArr
        {
            get { return (int[])Array.CreateInstance(typeof(int), new int[] { 4 }, new int[] { 1 }); }
        }

        private System.Array PrivArr2
        {
            get { return Array.CreateInstance(typeof(int), new int[] { 4 }, new int[] { 1 }); }
        }

        private int[] PrivArr3
        {
            get { return (int[])Array.CreateInstance(typeof(int), new int[] { 4 }); }
        }

        private System.Array PrivArr4
        {
            get { return Array.CreateInstance(typeof(int), new int[] { 4 }); }
        }
    }

    public interface InterfaceWithNonZeroLowerBound_Invalid
    {
        System.Array Id(System.Array arr);
        void Method2(System.Array arr);
        System.Array Method3();
    }

    internal interface InterfaceWithNonZeroLowerBound_Valid
    {
        System.Array Id(System.Array arr);
        void Method2(System.Array arr);
        System.Array Method3();
    }

   /* 
    * Valid tests include `internal` classes and `private` properties  
    *   and public methods in `ineternal` classes ?
    */
   internal class NZLBArraySignature_2D_PrivateClass_Valid
   {
       public System.Array Arr_2d { get; set; }
       public System.Array Arr_3d { get; set; }
       private System.Array PrivArr_2d { get; set; }
       private System.Array PrivArr_3d { get; set; }
   }
   public sealed class NZLBArraySignature_3D_Valid
   {
       private System.Array PrivArr_2d { get; set; }

       private Array PrivArr_3d { get; set; }
   }
        //  methods ??
   internal sealed class NZLBInternalPublic_Valid
   {
       public System.Array NZLB_ReturnOnly() { return new int[4, 2]; }
       public System.Array NZLB_ReturnAndInput1(System.Array arr) { return arr; }
       public System.Array NZLB_ReturnAndInput2of2(bool a, System.Array arr) { return arr; }
       public bool NZLB_NotReturnAndInput2of2(bool a, System.Array arr) { return a; }
       public bool NZLB_NotReturnAndInput2of3(bool a, System.Array arr, bool b) { return a; }
       public System.Array NZLB_ReturnAndInput2of3(bool a, System.Array arr, bool b) { return arr; }
   }

   internal sealed class D3InternalPublic_Valid
   {
       public System.Array NZLB_ReturnOnly() { return new int[2, 1, 3] { { { 1, 1, 1 } }, { { 2, 2, 2 } } }; }
       public System.Array NZLB_ReturnAndInput1(System.Array arr) { return arr; }
       public System.Array NZLB_ReturnAndInput2of2(bool a, System.Array arr) { return arr; }
       public System.Array NZLB_ReturnAndInput2of3(bool a, System.Array arr, bool b) { return arr; }
       public bool NZLB_NotReturnAndInput2of2(bool a, System.Array arr) { return a; }
       public bool NZLB_NotReturnAndInput2of3(bool a, System.Array arr, bool b) { return a; }
   }

   // tests return type and paramteter cases for 3-dimensional arrays 
   // we expect normal compilation since the methods are private 
   public sealed class NZLBPublicPrivate_Valid
   {
       private System.Array NZLB_ReturnOnly() { return new int[2, 1, 3] { { { 1, 1, 1 } }, { { 2, 2, 2 } } }; }
       private System.Array NZLB_ReturnAndInput1(System.Array arr) { return arr; }
       private System.Array NZLB_ReturnAndInput2of2(bool a, System.Array arr) { return arr; }
       private System.Array NZLB_ReturnAndInput2of3(bool a, System.Array arr, bool b) { return arr; }
       private bool NZLB_NotReturnAndInput2of2(bool a, System.Array arr) { return a; }
       private bool NZLB_NotReturnAndInput2of3(bool a, System.Array arr, bool b) { return a; }
   }

   public interface NZLB_ValidInterface_NoNZLB
   {
       int[] foo();
       bool bar(int[] arr);
   }
   /* 
    * Invalid tests include public properties in public classes, public interface methods, 
    */
   public sealed class NZLBArraySignature_2D_Invalid
   {
       public System.Array Arr_2d { get; set; }
       public System.Array Arr_3d { get; set; }
       private System.Array PrivArr_2d { get; set; } /* below should pass through undetected (private property) */
   }
        // tests return type and paramteter cases for 2-dimensional arrays 
   // we expect diagnostics to be raised since the methods are public
   public sealed class NZLBPublicPublic_Invalid
   {
       public System.Array NZLB_ReturnOnly() { return new int[4, 2]; }
       public System.Array NZLB_ReturnAndInput1(System.Array arr) { return arr; }
       public System.Array NZLB_ReturnAndInput2of2(bool a, System.Array arr) { return arr; }
       public bool NZLB_NotReturnAndInput2of2(bool a, System.Array arr) { return a; }
       public bool NZLB_NotReturnAndInput2of3(bool a, System.Array arr, bool b) { return a; }
       public System.Array NZLB_ReturnAndInput2of3(bool a, System.Array arr, bool b) { return arr; }
   }

   public interface NZLBMemberOfInterface_Invalid
   {
       public System.Array NZLB_ReturnOnly();
       public System.Array NZLB_ReturnAndInput1(System.Array arr);
       public System.Array NZLB_ReturnAndInput2of2(bool a, System.Array arr);
       public bool NZLB_NotReturnAndInput2of2(bool a, System.Array arr);
       public bool NZLB_NotReturnAndInput2of3(bool a, System.Array arr, bool b);
       public System.Array NZLB_ReturnAndInput2of3(bool a, System.Array arr, bool b);
   }

   namespace SubNamespace
   {
       public interface SubNamespacInterface_NZLBMethods_Invalid
       {
           public System.Array D2_ReturnOnly();
           public System.Array D2_ReturnAndInput1(System.Array arr);
           public System.Array D2_ReturnAndInput2of2(bool a, System.Array arr);
           public System.Array D2_ReturnAndInput2of3(bool a, System.Array arr, bool b);
           public bool D2_NotReturnAndInput2of2(bool a, System.Array arr);
           public bool D2_NotReturnAndInput2of3(bool a, System.Array arr, bool b);
       }
   }
} 