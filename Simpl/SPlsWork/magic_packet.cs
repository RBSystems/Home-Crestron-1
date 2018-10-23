using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_MAGIC_PACKET
{
    public class UserModuleClass_MAGIC_PACKET : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput WAKE;
        Crestron.Logos.SplusObjects.StringInput ADDRESS;
        Crestron.Logos.SplusObjects.StringOutput UDP__DOLLAR__;
        ushort I = 0;
        ushort J = 0;
        ushort MARKER = 0;
        ushort LAST = 0;
        CrestronString HEAD;
        CrestronString SUB;
        CrestronString HEXADDRESS;
        CrestronString MAGIC;
        object WAKE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 45;
                if ( Functions.TestForTrue  ( ( Functions.Length( HEXADDRESS ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 47;
                    UDP__DOLLAR__  .UpdateValue ( HEAD + MAGIC  ) ; 
                    __context__.SourceCodeLine = 48;
                    Print( "UDP$ Length={0:d}\r\n", (ushort)(Functions.Length( MAGIC ) + 6)) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    private ushort HEX (  SplusExecutionContext __context__,  ushort C ) 
        { 
        
        __context__.SourceCodeLine = 54;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( 48 <= C ) ) && Functions.TestForTrue ( Functions.BoolToInt ( C <= 57 ) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 54;
            return (ushort)( (C - 48)) ; 
            }
        
        __context__.SourceCodeLine = 55;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( 97 <= C ) ) && Functions.TestForTrue ( Functions.BoolToInt ( C <= 102 ) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 55;
            return (ushort)( ((C - 97) + 10)) ; 
            }
        
        __context__.SourceCodeLine = 56;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( 65 <= C ) ) && Functions.TestForTrue ( Functions.BoolToInt ( C <= 70 ) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 56;
            return (ushort)( ((C - 65) + 10)) ; 
            }
        
        __context__.SourceCodeLine = 57;
        return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
        
        }
        
    private ushort HTOI (  SplusExecutionContext __context__, ref CrestronString DATA ) 
        { 
        ushort MSN = 0;
        ushort LSN = 0;
        ushort C = 0;
        
        
        __context__.SourceCodeLine = 63;
        MSN = (ushort) ( HEX( __context__ , (ushort)( Functions.GetC( DATA ) ) ) ) ; 
        __context__.SourceCodeLine = 64;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( MSN < 0 ))  ) ) 
            {
            __context__.SourceCodeLine = 64;
            return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 67;
            LSN = (ushort) ( HEX( __context__ , (ushort)( Functions.GetC( DATA ) ) ) ) ; 
            __context__.SourceCodeLine = 68;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( LSN < 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 68;
                return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 71;
                return (ushort)( ((16 * MSN) + LSN)) ; 
                } 
            
            } 
        
        
        return 0; // default return value (none specified in module)
        }
        
    object ADDRESS_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort VAL = 0;
            
            
            __context__.SourceCodeLine = 79;
            MARKER = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 80;
            LAST = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 81;
            I = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 82;
            HEXADDRESS  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 83;
            MAGIC  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 84;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I < 6 ))  ) ) 
                { 
                __context__.SourceCodeLine = 86;
                MARKER = (ushort) ( Functions.Find( "-" , ADDRESS , (LAST + 1) ) ) ; 
                __context__.SourceCodeLine = 87;
                if ( Functions.TestForTrue  ( ( Functions.Not( MARKER ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 89;
                    Print( "Invalid MAC address, {0}\r\n", ADDRESS ) ; 
                    __context__.SourceCodeLine = 90;
                    break ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 94;
                    SUB  .UpdateValue ( Functions.Mid ( ADDRESS ,  (int) ( (LAST + 1) ) ,  (int) ( ((MARKER - LAST) - 1) ) )  ) ; 
                    __context__.SourceCodeLine = 95;
                    VAL = (ushort) ( HTOI( __context__ , ref SUB ) ) ; 
                    __context__.SourceCodeLine = 96;
                    Print( "Substring={0} [{1:X2}]\r\n", SUB , VAL) ; 
                    __context__.SourceCodeLine = 97;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VAL != 65535))  ) ) 
                        { 
                        __context__.SourceCodeLine = 99;
                        HEXADDRESS  .UpdateValue ( HEXADDRESS + Functions.Chr (  (int) ( VAL ) )  ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 103;
                        Print( "Invalid MAC address, {0}\r\n", ADDRESS ) ; 
                        __context__.SourceCodeLine = 104;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 106;
                    LAST = (ushort) ( MARKER ) ; 
                    } 
                
                __context__.SourceCodeLine = 108;
                I = (ushort) ( (I + 1) ) ; 
                __context__.SourceCodeLine = 84;
                } 
            
            __context__.SourceCodeLine = 110;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I == 6))  ) ) 
                { 
                __context__.SourceCodeLine = 112;
                SUB  .UpdateValue ( Functions.Mid ( ADDRESS ,  (int) ( (LAST + 1) ) ,  (int) ( (Functions.Length( ADDRESS ) - LAST) ) )  ) ; 
                __context__.SourceCodeLine = 113;
                VAL = (ushort) ( HTOI( __context__ , ref SUB ) ) ; 
                __context__.SourceCodeLine = 114;
                Print( "Substring={0} [{1:X2}]\r\n", SUB , VAL) ; 
                __context__.SourceCodeLine = 115;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VAL != 65535))  ) ) 
                    { 
                    __context__.SourceCodeLine = 117;
                    HEXADDRESS  .UpdateValue ( HEXADDRESS + Functions.Chr (  (int) ( VAL ) )  ) ; 
                    __context__.SourceCodeLine = 118;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)16; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 120;
                        MAGIC  .UpdateValue ( MAGIC + HEXADDRESS  ) ; 
                        __context__.SourceCodeLine = 118;
                        } 
                    
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 125;
                    Print( "Invalid MAC address, {0}\r\n", ADDRESS ) ; 
                    __context__.SourceCodeLine = 126;
                    HEXADDRESS  .UpdateValue ( ""  ) ; 
                    } 
                
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 134;
        ADDRESS  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 135;
        MAGIC  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 136;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)16; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 138;
            HEAD  .UpdateValue ( HEAD + Functions.Chr (  (int) ( 255 ) )  ) ; 
            __context__.SourceCodeLine = 136;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    HEAD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
    SUB  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    HEXADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    MAGIC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
    
    WAKE = new Crestron.Logos.SplusObjects.DigitalInput( WAKE__DigitalInput__, this );
    m_DigitalInputList.Add( WAKE__DigitalInput__, WAKE );
    
    ADDRESS = new Crestron.Logos.SplusObjects.StringInput( ADDRESS__AnalogSerialInput__, 17, this );
    m_StringInputList.Add( ADDRESS__AnalogSerialInput__, ADDRESS );
    
    UDP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( UDP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( UDP__DOLLAR____AnalogSerialOutput__, UDP__DOLLAR__ );
    
    
    WAKE.OnDigitalPush.Add( new InputChangeHandlerWrapper( WAKE_OnPush_0, false ) );
    ADDRESS.OnSerialChange.Add( new InputChangeHandlerWrapper( ADDRESS_OnChange_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MAGIC_PACKET ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint WAKE__DigitalInput__ = 0;
const uint ADDRESS__AnalogSerialInput__ = 0;
const uint UDP__DOLLAR____AnalogSerialOutput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
