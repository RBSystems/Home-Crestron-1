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
using CrestronKNXLibrary.Data_Types;
using CrestronKNXLibrary.General;
using CrestronKNXLibrary.Routing;
using CrestronKNXLibrary.Communication;

namespace UserModule_CRESTRON_KNX_4_BIT_V3_0
{
    public class UserModuleClass_CRESTRON_KNX_4_BIT_V3_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput POLL_VALUE;
        Crestron.Logos.SplusObjects.DigitalInput UP;
        Crestron.Logos.SplusObjects.DigitalInput DOWN;
        Crestron.Logos.SplusObjects.DigitalOutput INITIALIZATIONISCOMPLETE;
        Crestron.Logos.SplusObjects.DigitalOutput UP_FEEDBACK;
        Crestron.Logos.SplusObjects.DigitalOutput DOWN_FEEDBACK;
        UShortParameter IPGATEWAYID;
        StringParameter SPADDRESS;
        CrestronKNXLibrary.Data_Types.KNXFourBitSimplSharpComponent SIMPLSHARPCOMPONENT;
        object INITIALIZE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 86;
                SIMPLSHARPCOMPONENT . InitializeSettings ( (int)( IPGATEWAYID  .Value ), GetSymbolReferenceName() .ToString(), SPADDRESS  .ToString()) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object POLL_VALUE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 91;
            SIMPLSHARPCOMPONENT . PollValue ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object UP_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 97;
        SIMPLSHARPCOMPONENT . DimUp ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object UP_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 103;
        SIMPLSHARPCOMPONENT . StopDimming ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DOWN_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 109;
        SIMPLSHARPCOMPONENT . DimDown ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DOWN_OnRelease_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 115;
        SIMPLSHARPCOMPONENT . StopDimming ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void UPDATEFOURBITVALUECALLBACK ( int VALUE ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 125;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUE == 9))  ) ) 
            {
            __context__.SourceCodeLine = 126;
            UP_FEEDBACK  .Value = (ushort) ( 1 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 127;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VALUE == 1))  ) ) 
                {
                __context__.SourceCodeLine = 128;
                DOWN_FEEDBACK  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 129;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (VALUE == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (VALUE == 8) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 131;
                    UP_FEEDBACK  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 132;
                    DOWN_FEEDBACK  .Value = (ushort) ( 0 ) ; 
                    } 
                
                }
            
            }
        
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public void INITIALIZATIONISCOMPLETECALLBACK ( int TEMPSTATE ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 139;
        INITIALIZATIONISCOMPLETE  .Value = (ushort) ( TEMPSTATE ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public void BASICINITIALIZATIONISCOMPLETEHANDLER ( ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 146;
        // RegisterDelegate( SIMPLSHARPCOMPONENT , INITIALIZATIONISCOMPLETE , INITIALIZATIONISCOMPLETECALLBACK ) 
        SIMPLSHARPCOMPONENT .initializationIsComplete  = INITIALIZATIONISCOMPLETECALLBACK; ; 
        __context__.SourceCodeLine = 147;
        // RegisterDelegate( SIMPLSHARPCOMPONENT , UPDATEFOURBITVALUE , UPDATEFOURBITVALUECALLBACK ) 
        SIMPLSHARPCOMPONENT .UpdateFourBitValue  = UPDATEFOURBITVALUECALLBACK; ; 
        __context__.SourceCodeLine = 151;
        SIMPLSHARPCOMPONENT . BeginInitialization ( ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 161;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 162;
        // RegisterDelegate( SIMPLSHARPCOMPONENT , BASICINITIALIZATIONISCOMPLETE , BASICINITIALIZATIONISCOMPLETEHANDLER ) 
        SIMPLSHARPCOMPONENT .basicInitializationIsComplete  = BASICINITIALIZATIONISCOMPLETEHANDLER; ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    POLL_VALUE = new Crestron.Logos.SplusObjects.DigitalInput( POLL_VALUE__DigitalInput__, this );
    m_DigitalInputList.Add( POLL_VALUE__DigitalInput__, POLL_VALUE );
    
    UP = new Crestron.Logos.SplusObjects.DigitalInput( UP__DigitalInput__, this );
    m_DigitalInputList.Add( UP__DigitalInput__, UP );
    
    DOWN = new Crestron.Logos.SplusObjects.DigitalInput( DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( DOWN__DigitalInput__, DOWN );
    
    INITIALIZATIONISCOMPLETE = new Crestron.Logos.SplusObjects.DigitalOutput( INITIALIZATIONISCOMPLETE__DigitalOutput__, this );
    m_DigitalOutputList.Add( INITIALIZATIONISCOMPLETE__DigitalOutput__, INITIALIZATIONISCOMPLETE );
    
    UP_FEEDBACK = new Crestron.Logos.SplusObjects.DigitalOutput( UP_FEEDBACK__DigitalOutput__, this );
    m_DigitalOutputList.Add( UP_FEEDBACK__DigitalOutput__, UP_FEEDBACK );
    
    DOWN_FEEDBACK = new Crestron.Logos.SplusObjects.DigitalOutput( DOWN_FEEDBACK__DigitalOutput__, this );
    m_DigitalOutputList.Add( DOWN_FEEDBACK__DigitalOutput__, DOWN_FEEDBACK );
    
    IPGATEWAYID = new UShortParameter( IPGATEWAYID__Parameter__, this );
    m_ParameterList.Add( IPGATEWAYID__Parameter__, IPGATEWAYID );
    
    SPADDRESS = new StringParameter( SPADDRESS__Parameter__, this );
    m_ParameterList.Add( SPADDRESS__Parameter__, SPADDRESS );
    
    
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
    POLL_VALUE.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_VALUE_OnPush_1, false ) );
    UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( UP_OnPush_2, false ) );
    UP.OnDigitalRelease.Add( new InputChangeHandlerWrapper( UP_OnRelease_3, false ) );
    DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( DOWN_OnPush_4, false ) );
    DOWN.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DOWN_OnRelease_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    SIMPLSHARPCOMPONENT  = new CrestronKNXLibrary.Data_Types.KNXFourBitSimplSharpComponent();
    
    
}

public UserModuleClass_CRESTRON_KNX_4_BIT_V3_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE__DigitalInput__ = 0;
const uint POLL_VALUE__DigitalInput__ = 1;
const uint UP__DigitalInput__ = 2;
const uint DOWN__DigitalInput__ = 3;
const uint INITIALIZATIONISCOMPLETE__DigitalOutput__ = 0;
const uint UP_FEEDBACK__DigitalOutput__ = 1;
const uint DOWN_FEEDBACK__DigitalOutput__ = 2;
const uint IPGATEWAYID__Parameter__ = 10;
const uint SPADDRESS__Parameter__ = 11;

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
