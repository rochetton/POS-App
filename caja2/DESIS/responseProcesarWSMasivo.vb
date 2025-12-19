Namespace APIDESIS

    '''<remarks/>
    <System.SerializableAttribute(),
    System.ComponentModel.DesignerCategoryAttribute("code"),
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2003/05/soap-envelope"),
    System.Xml.Serialization.XmlRootAttribute(ElementName:="Envelope", [Namespace]:="http://www.w3.org/2003/05/soap-envelope", IsNullable:=False)>
    Partial Public Class EnvelopeResponseProcesarWSMasivo

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

        Private procesarWSMasivoResponseField As ProcesarWSMasivoResponse

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://tempuri.org")>
        Public Property ProcesarWSMasivoResponse() As ProcesarWSMasivoResponse
            Get
                Return Me.procesarWSMasivoResponseField
            End Get
            Set
                Me.procesarWSMasivoResponseField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
    System.ComponentModel.DesignerCategoryAttribute("code"),
    System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org"),
    System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org", IsNullable:=False)>
    Partial Public Class ProcesarWSMasivoResponse

        Private procesarWSMasivoResultField As String

        '''<remarks/>
        Public Property ProcesarWSMasivoResult() As String
            Get
                Return Me.procesarWSMasivoResultField
            End Get
            Set
                Me.procesarWSMasivoResultField = Value
            End Set
        End Property
    End Class


End Namespace