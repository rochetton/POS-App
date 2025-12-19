Namespace APIDESIS

    <System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://www.w3.org/2003/05/soap-envelope"),
     System.Xml.Serialization.XmlRootAttribute(ElementName:="Envelope", [Namespace]:="http://www.w3.org/2003/05/soap-envelope", IsNullable:=False)>
    Partial Public Class EnvelopeProcesar

        Private headerField As Object

        Private bodyField As EnvelopeBodyProcesar

        Public Sub New()
            Me.Body = New APIDESIS.EnvelopeBodyProcesar()
            Me.Body.Procesar = New APIDESIS.Procesar()
            Me.Body.Procesar.login = New APIDESIS.ProcesarLogin()
        End Sub

        '''<remarks/>
        Public Property Header() As Object
            Get
                Return Me.headerField
            End Get
            Set
                Me.headerField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Body() As EnvelopeBodyProcesar
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
    System.Xml.Serialization.XmlRootAttribute(ElementName:="EnvelopeBody", [Namespace]:="http://www.w3.org/2003/05/soap-envelope", IsNullable:=False)>
    Partial Public Class EnvelopeBodyProcesar

        Private procesarField As Procesar

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://tempuri.org")>
        Public Property Procesar() As Procesar
            Get
                Return Me.procesarField
            End Get
            Set
                Me.procesarField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org"),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org", IsNullable:=False)>
    Partial Public Class Procesar

        Private loginField As ProcesarLogin

        Private fileField As String

        Private formatoField As Byte

        '''<remarks/>
        Public Property login() As ProcesarLogin
            Get
                Return Me.loginField
            End Get
            Set
                Me.loginField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property file() As String
            Get
                Return Me.fileField
            End Get
            Set
                Me.fileField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property formato() As Byte
            Get
                Return Me.formatoField
            End Get
            Set
                Me.formatoField = Value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org")>
    Partial Public Class ProcesarLogin

        Private usuarioField As String

        Private rutField As String

        Private claveField As String

        Private puertoField As String

        Private incluyeLinkField As Byte

        '''<remarks/>
        Public Property Usuario() As String
            Get
                Return Me.usuarioField
            End Get
            Set
                Me.usuarioField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Rut() As String
            Get
                Return Me.rutField
            End Get
            Set
                Me.rutField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Clave() As String
            Get
                Return Me.claveField
            End Get
            Set
                Me.claveField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property Puerto() As String
            Get
                Return Me.puertoField
            End Get
            Set
                Me.puertoField = Value
            End Set
        End Property

        '''<remarks/>
        Public Property IncluyeLink() As Byte
            Get
                Return Me.incluyeLinkField
            End Get
            Set
                Me.incluyeLinkField = Value
            End Set
        End Property
    End Class

End Namespace
