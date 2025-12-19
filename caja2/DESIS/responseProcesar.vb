
<System.SerializableAttribute(),
System.ComponentModel.DesignerCategoryAttribute("code"),
System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2003/05/soap-envelope"),
System.Xml.Serialization.XmlRootAttribute(ElementName:="Envelope", [Namespace]:="http://www.w3.org/2003/05/soap-envelope", IsNullable:=False)>
Partial Public Class EnvelopeResponseProcesar

    Private bodyField As EnvelopeBody

    '''<remarks/>
    Public Property Body() As EnvelopeBody
        Get
            Return Me.bodyField
        End Get
        Set
            Me.bodyField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2003/05/soap-envelope")>
    Partial Public Class EnvelopeBody

        Private procesarResponseField As ProcesarResponse

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://tempuri.org")>
        Public Property ProcesarResponse() As ProcesarResponse
            Get
                Return Me.procesarResponseField
            End Get
            Set
                Me.procesarResponseField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org", IsNullable:=False)>
    Partial Public Class ProcesarResponse

        Private procesarResultField As Object

        '''<remarks/>
        Public Property ProcesarResult() As Object
            Get
                Return Me.procesarResultField
            End Get
            Set
                Me.procesarResultField = Value
            End Set
        End Property
    End Class


