'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2003/05/soap-envelope"),
 System.Xml.Serialization.XmlRootAttribute(ElementName:="Envelope", [Namespace]:="http://www.w3.org/2003/05/soap-envelope", IsNullable:=False)>
Partial Public Class EnvelopeResponseConsultarEstado

    Private bodyField As EnvelopeBodyResponseConsultarEstado

    '''<remarks/>
    Public Property Body() As EnvelopeBodyResponseConsultarEstado
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
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2003/05/soap-envelope"),
 System.Xml.Serialization.XmlRootAttribute(ElementName:="EnvelopeBody", [Namespace]:="http://www.w3.org/2003/05/soap-envelope")>
Partial Public Class EnvelopeBodyResponseConsultarEstado

    Private consultarEstadoResponseField As ConsultarEstadoResponse

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://tempuri.org")>
    Public Property ConsultarEstadoResponse() As ConsultarEstadoResponse
        Get
            Return Me.consultarEstadoResponseField
        End Get
        Set
            Me.consultarEstadoResponseField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org", IsNullable:=False)>
Partial Public Class ConsultarEstadoResponse

    Private consultarEstadoResultField As Object

    '''<remarks/>
    Public Property ConsultarEstadoResult() As Object
        Get
            Return Me.consultarEstadoResultField
        End Get
        Set
            Me.consultarEstadoResultField = Value
        End Set
    End Property
End Class

