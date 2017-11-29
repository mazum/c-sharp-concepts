using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

[Serializable]
class Car:Automobile, ISerializable
{
    public bool IsHatchback;

    public Car()
    {
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("IsHatchback", IsHatchback);

        //Get base type Automobile
        Type baseType = this.GetType().BaseType;
        //Get serializable members of Automobile
        MemberInfo[] memberInfo = FormatterServices.GetSerializableMembers(baseType, context);

        for (int i = 0; i < memberInfo.Length; i++)
        {
            //Cast members to fields and add them to SerializationInfo
            //to be serialized
            info.AddValue(baseType.FullName + "." + memberInfo[i].Name, ((FieldInfo) memberInfo[i]).GetValue(this));
        }
    }

    protected Car(SerializationInfo info, StreamingContext context)
    {
        IsHatchback = info.GetBoolean("IsHatchback");

        //Get base type Automobile
        Type baseType = this.GetType().BaseType;
        //Get serializable members
        MemberInfo[] memberInfo = FormatterServices.GetSerializableMembers(baseType, context);

        for (Int32 i = 0; i < memberInfo.Length; i++)
        {
            //Cast members to fields
            FieldInfo fieldInfo = (FieldInfo) memberInfo[i];
            //Extract values from SerializationInfo
            //and populate fields
            fieldInfo.SetValue(this, info.GetValue(baseType.FullName + "." + fieldInfo.Name, fieldInfo.FieldType));
        }
    }
}
