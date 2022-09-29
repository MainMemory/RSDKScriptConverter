using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RSDKScriptConverter.ScriptReadModes;
using static RSDKScriptConverter.ScriptParseModes;

namespace RSDKScriptConverter
{
	class ScriptEngineV4Old : ScriptEngine
	{
		readonly VarNameList varNames = new VarNameList()
		{
			// Internal Script Values
			{ "temp0", CommonScrVar.VAR_TEMP0 },
			{ "temp1", CommonScrVar.VAR_TEMP1 },
			{ "temp2", CommonScrVar.VAR_TEMP2 },
			{ "temp3", CommonScrVar.VAR_TEMP3 },
			{ "temp4", CommonScrVar.VAR_TEMP4 },
			{ "temp5", CommonScrVar.VAR_TEMP5 },
			{ "temp6", CommonScrVar.VAR_TEMP6 },
			{ "temp7", CommonScrVar.VAR_TEMP7 },
			{ "checkResult", CommonScrVar.VAR_CHECKRESULT },
			{ "arrayPos0", CommonScrVar.VAR_ARRAYPOS0 },
			{ "arrayPos1", CommonScrVar.VAR_ARRAYPOS1 },
			{ "arrayPos2", CommonScrVar.VAR_ARRAYPOS2 },
			{ "arrayPos3", CommonScrVar.VAR_ARRAYPOS3 },
			{ "arrayPos4", CommonScrVar.VAR_ARRAYPOS4 },
			{ "arrayPos5", CommonScrVar.VAR_ARRAYPOS5 },
			{ "arrayPos6", CommonScrVar.VAR_ARRAYPOS6 },
			{ "arrayPos7", CommonScrVar.VAR_ARRAYPOS7 },
			{ "global", CommonScrVar.VAR_GLOBAL },
			{ "local", CommonScrVar.VAR_LOCAL },

			// Object Properties
			{ "object.entityPos", CommonScrVar.VAR_OBJECTENTITYPOS },
			{ "object.groupID", CommonScrVar.VAR_OBJECTGROUPID },
			{ "object.type", CommonScrVar.VAR_OBJECTTYPE },
			{ "object.propertyValue", CommonScrVar.VAR_OBJECTPROPERTYVALUE },
			{ "object.xpos", CommonScrVar.VAR_OBJECTXPOS },
			{ "object.ypos", CommonScrVar.VAR_OBJECTYPOS },
			{ "object.ixpos", CommonScrVar.VAR_OBJECTIXPOS },
			{ "object.iypos", CommonScrVar.VAR_OBJECTIYPOS },
			{ "object.xvel", CommonScrVar.VAR_OBJECTXVEL },
			{ "object.yvel", CommonScrVar.VAR_OBJECTYVEL },
			{ "object.speed", CommonScrVar.VAR_OBJECTSPEED },
			{ "object.state", CommonScrVar.VAR_OBJECTSTATE },
			{ "object.rotation", CommonScrVar.VAR_OBJECTROTATION },
			{ "object.scale", CommonScrVar.VAR_OBJECTSCALE },
			{ "object.priority", CommonScrVar.VAR_OBJECTPRIORITY },
			{ "object.drawOrder", CommonScrVar.VAR_OBJECTDRAWORDER },
			{ "object.direction", CommonScrVar.VAR_OBJECTDIRECTION },
			{ "object.inkEffect", CommonScrVar.VAR_OBJECTINKEFFECT },
			{ "object.alpha", CommonScrVar.VAR_OBJECTALPHA },
			{ "object.frame", CommonScrVar.VAR_OBJECTFRAME },
			{ "object.animation", CommonScrVar.VAR_OBJECTANIMATION },
			{ "object.prevAnimation", CommonScrVar.VAR_OBJECTPREVANIMATION },
			{ "object.animationSpeed", CommonScrVar.VAR_OBJECTANIMATIONSPEED },
			{ "object.animationTimer", CommonScrVar.VAR_OBJECTANIMATIONTIMER },
			{ "object.angle", CommonScrVar.VAR_OBJECTANGLE },
			{ "object.lookPosX", CommonScrVar.VAR_OBJECTLOOKPOSX },
			{ "object.lookPosY", CommonScrVar.VAR_OBJECTLOOKPOSY },
			{ "object.collisionMode", CommonScrVar.VAR_OBJECTCOLLISIONMODE },
			{ "object.collisionPlane", CommonScrVar.VAR_OBJECTCOLLISIONPLANE },
			{ "object.controlMode", CommonScrVar.VAR_OBJECTCONTROLMODE },
			{ "object.controlLock", CommonScrVar.VAR_OBJECTCONTROLLOCK },
			{ "object.pushing", CommonScrVar.VAR_OBJECTPUSHING },
			{ "object.visible", CommonScrVar.VAR_OBJECTVISIBLE },
			{ "object.tileCollisions", CommonScrVar.VAR_OBJECTTILECOLLISIONS },
			{ "object.interaction", CommonScrVar.VAR_OBJECTINTERACTION },
			{ "object.gravity", CommonScrVar.VAR_OBJECTGRAVITY },
			{ "object.up", CommonScrVar.VAR_OBJECTUP },
			{ "object.down", CommonScrVar.VAR_OBJECTDOWN },
			{ "object.left", CommonScrVar.VAR_OBJECTLEFT },
			{ "object.right", CommonScrVar.VAR_OBJECTRIGHT },
			{ "object.jumpPress", CommonScrVar.VAR_OBJECTJUMPPRESS },
			{ "object.jumpHold", CommonScrVar.VAR_OBJECTJUMPHOLD },
			{ "object.scrollTracking", CommonScrVar.VAR_OBJECTSCROLLTRACKING },
			{ "object.floorSensorL", CommonScrVar.VAR_OBJECTFLOORSENSORL },
			{ "object.floorSensorC", CommonScrVar.VAR_OBJECTFLOORSENSORC },
			{ "object.floorSensorR", CommonScrVar.VAR_OBJECTFLOORSENSORR },
			{ "object.floorSensorLC", CommonScrVar.VAR_OBJECTFLOORSENSORLC },
			{ "object.floorSensorRC", CommonScrVar.VAR_OBJECTFLOORSENSORRC },
			{ "object.collisionLeft", CommonScrVar.VAR_OBJECTCOLLISIONLEFT },
			{ "object.collisionTop", CommonScrVar.VAR_OBJECTCOLLISIONTOP },
			{ "object.collisionRight", CommonScrVar.VAR_OBJECTCOLLISIONRIGHT },
			{ "object.collisionBottom", CommonScrVar.VAR_OBJECTCOLLISIONBOTTOM },
			{ "object.outOfBounds", CommonScrVar.VAR_OBJECTOUTOFBOUNDS },
			{ "object.spriteSheet", CommonScrVar.VAR_OBJECTSPRITESHEET },

			// Object Values
			{ "object.value0", CommonScrVar.VAR_OBJECTVALUE0 },
			{ "object.value1", CommonScrVar.VAR_OBJECTVALUE1 },
			{ "object.value2", CommonScrVar.VAR_OBJECTVALUE2 },
			{ "object.value3", CommonScrVar.VAR_OBJECTVALUE3 },
			{ "object.value4", CommonScrVar.VAR_OBJECTVALUE4 },
			{ "object.value5", CommonScrVar.VAR_OBJECTVALUE5 },
			{ "object.value6", CommonScrVar.VAR_OBJECTVALUE6 },
			{ "object.value7", CommonScrVar.VAR_OBJECTVALUE7 },
			{ "object.value8", CommonScrVar.VAR_OBJECTVALUE8 },
			{ "object.value9", CommonScrVar.VAR_OBJECTVALUE9 },
			{ "object.value10", CommonScrVar.VAR_OBJECTVALUE10 },
			{ "object.value11", CommonScrVar.VAR_OBJECTVALUE11 },
			{ "object.value12", CommonScrVar.VAR_OBJECTVALUE12 },
			{ "object.value13", CommonScrVar.VAR_OBJECTVALUE13 },
			{ "object.value14", CommonScrVar.VAR_OBJECTVALUE14 },
			{ "object.value15", CommonScrVar.VAR_OBJECTVALUE15 },
			{ "object.value16", CommonScrVar.VAR_OBJECTVALUE16 },
			{ "object.value17", CommonScrVar.VAR_OBJECTVALUE17 },
			{ "object.value18", CommonScrVar.VAR_OBJECTVALUE18 },
			{ "object.value19", CommonScrVar.VAR_OBJECTVALUE19 },
			{ "object.value20", CommonScrVar.VAR_OBJECTVALUE20 },
			{ "object.value21", CommonScrVar.VAR_OBJECTVALUE21 },
			{ "object.value22", CommonScrVar.VAR_OBJECTVALUE22 },
			{ "object.value23", CommonScrVar.VAR_OBJECTVALUE23 },
			{ "object.value24", CommonScrVar.VAR_OBJECTVALUE24 },
			{ "object.value25", CommonScrVar.VAR_OBJECTVALUE25 },
			{ "object.value26", CommonScrVar.VAR_OBJECTVALUE26 },
			{ "object.value27", CommonScrVar.VAR_OBJECTVALUE27 },
			{ "object.value28", CommonScrVar.VAR_OBJECTVALUE28 },
			{ "object.value29", CommonScrVar.VAR_OBJECTVALUE29 },
			{ "object.value30", CommonScrVar.VAR_OBJECTVALUE30 },
			{ "object.value31", CommonScrVar.VAR_OBJECTVALUE31 },
			{ "object.value32", CommonScrVar.VAR_OBJECTVALUE32 },
			{ "object.value33", CommonScrVar.VAR_OBJECTVALUE33 },
			{ "object.value34", CommonScrVar.VAR_OBJECTVALUE34 },
			{ "object.value35", CommonScrVar.VAR_OBJECTVALUE35 },
			{ "object.value36", CommonScrVar.VAR_OBJECTVALUE36 },
			{ "object.value37", CommonScrVar.VAR_OBJECTVALUE37 },
			{ "object.value38", CommonScrVar.VAR_OBJECTVALUE38 },
			{ "object.value39", CommonScrVar.VAR_OBJECTVALUE39 },
			{ "object.value40", CommonScrVar.VAR_OBJECTVALUE40 },
			{ "object.value41", CommonScrVar.VAR_OBJECTVALUE41 },
			{ "object.value42", CommonScrVar.VAR_OBJECTVALUE42 },
			{ "object.value43", CommonScrVar.VAR_OBJECTVALUE43 },
			{ "object.value44", CommonScrVar.VAR_OBJECTVALUE44 },
			{ "object.value45", CommonScrVar.VAR_OBJECTVALUE45 },
			{ "object.value46", CommonScrVar.VAR_OBJECTVALUE46 },
			{ "object.value47", CommonScrVar.VAR_OBJECTVALUE47 },

			// Stage Properties
			{ "stage.state", CommonScrVar.VAR_STAGESTATE },
			{ "stage.activeList", CommonScrVar.VAR_STAGEACTIVELIST },
			{ "stage.listPos", CommonScrVar.VAR_STAGELISTPOS },
			{ "stage.timeEnabled", CommonScrVar.VAR_STAGETIMEENABLED },
			{ "stage.milliSeconds", CommonScrVar.VAR_STAGEMILLISECONDS },
			{ "stage.seconds", CommonScrVar.VAR_STAGESECONDS },
			{ "stage.minutes", CommonScrVar.VAR_STAGEMINUTES },
			{ "stage.actNum", CommonScrVar.VAR_STAGEACTNUM },
			{ "stage.pauseEnabled", CommonScrVar.VAR_STAGEPAUSEENABLED },
			{ "stage.listSize", CommonScrVar.VAR_STAGELISTSIZE },
			{ "stage.newXBoundary1", CommonScrVar.VAR_STAGENEWXBOUNDARY1 },
			{ "stage.newXBoundary2", CommonScrVar.VAR_STAGENEWXBOUNDARY2 },
			{ "stage.newYBoundary1", CommonScrVar.VAR_STAGENEWYBOUNDARY1 },
			{ "stage.newYBoundary2", CommonScrVar.VAR_STAGENEWYBOUNDARY2 },
			{ "stage.curXBoundary1", CommonScrVar.VAR_STAGECURXBOUNDARY1 },
			{ "stage.curXBoundary2", CommonScrVar.VAR_STAGECURXBOUNDARY2 },
			{ "stage.curYBoundary1", CommonScrVar.VAR_STAGECURYBOUNDARY1 },
			{ "stage.curYBoundary2", CommonScrVar.VAR_STAGECURYBOUNDARY2 },
			{ "stage.deformationData0", CommonScrVar.VAR_STAGEDEFORMATIONDATA0 },
			{ "stage.deformationData1", CommonScrVar.VAR_STAGEDEFORMATIONDATA1 },
			{ "stage.deformationData2", CommonScrVar.VAR_STAGEDEFORMATIONDATA2 },
			{ "stage.deformationData3", CommonScrVar.VAR_STAGEDEFORMATIONDATA3 },
			{ "stage.waterLevel", CommonScrVar.VAR_STAGEWATERLEVEL },
			{ "stage.activeLayer", CommonScrVar.VAR_STAGEACTIVELAYER },
			{ "stage.midPoint", CommonScrVar.VAR_STAGEMIDPOINT },
			{ "stage.playerListPos", CommonScrVar.VAR_STAGEPLAYERLISTPOS },
			{ "stage.debugMode", CommonScrVar.VAR_STAGEDEBUGMODE },
			{ "stage.entityPos", CommonScrVar.VAR_STAGEENTITYPOS },

			// Screen Properties
			{ "screen.cameraEnabled", CommonScrVar.VAR_SCREENCAMERAENABLED },
			{ "screen.cameraTarget", CommonScrVar.VAR_SCREENCAMERATARGET },
			{ "screen.cameraStyle", CommonScrVar.VAR_SCREENCAMERASTYLE },
			{ "screen.cameraX", CommonScrVar.VAR_SCREENCAMERAX },
			{ "screen.cameraY", CommonScrVar.VAR_SCREENCAMERAY },
			{ "screen.drawListSize", CommonScrVar.VAR_SCREENDRAWLISTSIZE },
			{ "screen.xcenter", CommonScrVar.VAR_SCREENXCENTER },
			{ "screen.ycenter", CommonScrVar.VAR_SCREENYCENTER },
			{ "screen.xsize", CommonScrVar.VAR_SCREENXSIZE },
			{ "screen.ysize", CommonScrVar.VAR_SCREENYSIZE },
			{ "screen.xoffset", CommonScrVar.VAR_SCREENXOFFSET },
			{ "screen.yoffset", CommonScrVar.VAR_SCREENYOFFSET },
			{ "screen.shakeX", CommonScrVar.VAR_SCREENSHAKEX },
			{ "screen.shakeY", CommonScrVar.VAR_SCREENSHAKEY },
			{ "screen.adjustCameraY", CommonScrVar.VAR_SCREENADJUSTCAMERAY },

			{ "touchscreen.down", CommonScrVar.VAR_TOUCHSCREENDOWN },
			{ "touchscreen.xpos", CommonScrVar.VAR_TOUCHSCREENXPOS },
			{ "touchscreen.ypos", CommonScrVar.VAR_TOUCHSCREENYPOS },

			// Sound Properties
			{ "music.volume", CommonScrVar.VAR_MUSICVOLUME },
			{ "music.currentTrack", CommonScrVar.VAR_MUSICCURRENTTRACK },
			{ "music.position", CommonScrVar.VAR_MUSICPOSITION },

			// Input Properties
			{ "inputDown.up", CommonScrVar.VAR_KEYDOWNUP },
			{ "inputDown.down", CommonScrVar.VAR_KEYDOWNDOWN },
			{ "inputDown.left", CommonScrVar.VAR_KEYDOWNLEFT },
			{ "inputDown.right", CommonScrVar.VAR_KEYDOWNRIGHT },
			{ "inputDown.buttonA", CommonScrVar.VAR_KEYDOWNBUTTONA },
			{ "inputDown.buttonB", CommonScrVar.VAR_KEYDOWNBUTTONB },
			{ "inputDown.buttonC", CommonScrVar.VAR_KEYDOWNBUTTONC },
			{ "inputDown.buttonX", CommonScrVar.VAR_KEYDOWNBUTTONX },
			{ "inputDown.buttonY", CommonScrVar.VAR_KEYDOWNBUTTONY },
			{ "inputDown.buttonZ", CommonScrVar.VAR_KEYDOWNBUTTONZ },
			{ "inputDown.buttonL", CommonScrVar.VAR_KEYDOWNBUTTONL },
			{ "inputDown.buttonR", CommonScrVar.VAR_KEYDOWNBUTTONR },
			{ "inputDown.start", CommonScrVar.VAR_KEYDOWNSTART },
			{ "inputDown.select", CommonScrVar.VAR_KEYDOWNSELECT },
			{ "inputPress.up", CommonScrVar.VAR_KEYPRESSUP },
			{ "inputPress.down", CommonScrVar.VAR_KEYPRESSDOWN },
			{ "inputPress.left", CommonScrVar.VAR_KEYPRESSLEFT },
			{ "inputPress.right", CommonScrVar.VAR_KEYPRESSRIGHT },
			{ "inputPress.buttonA", CommonScrVar.VAR_KEYPRESSBUTTONA },
			{ "inputPress.buttonB", CommonScrVar.VAR_KEYPRESSBUTTONB },
			{ "inputPress.buttonC", CommonScrVar.VAR_KEYPRESSBUTTONC },
			{ "inputPress.buttonX", CommonScrVar.VAR_KEYPRESSBUTTONX },
			{ "inputPress.buttonY", CommonScrVar.VAR_KEYPRESSBUTTONY },
			{ "inputPress.buttonZ", CommonScrVar.VAR_KEYPRESSBUTTONZ },
			{ "inputPress.buttonL", CommonScrVar.VAR_KEYPRESSBUTTONL },
			{ "inputPress.buttonR", CommonScrVar.VAR_KEYPRESSBUTTONR },
			{ "inputPress.start", CommonScrVar.VAR_KEYPRESSSTART },
			{ "inputPress.select", CommonScrVar.VAR_KEYPRESSSELECT },

			// Menu Properties
			{ "menu1.selection", CommonScrVar.VAR_MENU1SELECTION },
			{ "menu2.selection", CommonScrVar.VAR_MENU2SELECTION },

			// Tile Layer Properties
			{ "tileLayer.xsize", CommonScrVar.VAR_TILELAYERXSIZE },
			{ "tileLayer.ysize", CommonScrVar.VAR_TILELAYERYSIZE },
			{ "tileLayer.type", CommonScrVar.VAR_TILELAYERTYPE },
			{ "tileLayer.angle", CommonScrVar.VAR_TILELAYERANGLE },
			{ "tileLayer.xpos", CommonScrVar.VAR_TILELAYERXPOS },
			{ "tileLayer.ypos", CommonScrVar.VAR_TILELAYERYPOS },
			{ "tileLayer.zpos", CommonScrVar.VAR_TILELAYERZPOS },
			{ "tileLayer.parallaxFactor", CommonScrVar.VAR_TILELAYERPARALLAXFACTOR },
			{ "tileLayer.scrollSpeed", CommonScrVar.VAR_TILELAYERSCROLLSPEED },
			{ "tileLayer.scrollPos", CommonScrVar.VAR_TILELAYERSCROLLPOS },
			{ "tileLayer.deformationOffset", CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSET },
			{ "tileLayer.deformationOffsetW", CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSETW },
			{ "hParallax.parallaxFactor", CommonScrVar.VAR_HPARALLAXPARALLAXFACTOR },
			{ "hParallax.scrollSpeed", CommonScrVar.VAR_HPARALLAXSCROLLSPEED },
			{ "hParallax.scrollPos", CommonScrVar.VAR_HPARALLAXSCROLLPOS },
			{ "vParallax.parallaxFactor", CommonScrVar.VAR_VPARALLAXPARALLAXFACTOR },
			{ "vParallax.scrollSpeed", CommonScrVar.VAR_VPARALLAXSCROLLSPEED },
			{ "vParallax.scrollPos", CommonScrVar.VAR_VPARALLAXSCROLLPOS },

			// 3D Scene Properties
			{ "scene3D.vertexCount", CommonScrVar.VAR_SCENE3DVERTEXCOUNT },
			{ "scene3D.faceCount", CommonScrVar.VAR_SCENE3DFACECOUNT },
			{ "scene3D.projectionX", CommonScrVar.VAR_SCENE3DPROJECTIONX },
			{ "scene3D.projectionY", CommonScrVar.VAR_SCENE3DPROJECTIONY },
			{ "scene3D.fogColor", CommonScrVar.VAR_SCENE3DFOGCOLOR },
			{ "scene3D.fogStrength", CommonScrVar.VAR_SCENE3DFOGSTRENGTH },

			{ "vertexBuffer.x", CommonScrVar.VAR_VERTEXBUFFERX },
			{ "vertexBuffer.y", CommonScrVar.VAR_VERTEXBUFFERY },
			{ "vertexBuffer.z", CommonScrVar.VAR_VERTEXBUFFERZ },
			{ "vertexBuffer.u", CommonScrVar.VAR_VERTEXBUFFERU },
			{ "vertexBuffer.v", CommonScrVar.VAR_VERTEXBUFFERV },

			{ "faceBuffer.a", CommonScrVar.VAR_FACEBUFFERA },
			{ "faceBuffer.b", CommonScrVar.VAR_FACEBUFFERB },
			{ "faceBuffer.c", CommonScrVar.VAR_FACEBUFFERC },
			{ "faceBuffer.d", CommonScrVar.VAR_FACEBUFFERD },
			{ "faceBuffer.flag", CommonScrVar.VAR_FACEBUFFERFLAG },
			{ "faceBuffer.color", CommonScrVar.VAR_FACEBUFFERCOLOR },

			{ "saveRAM", CommonScrVar.VAR_SAVERAM },
			{ "engine.state", CommonScrVar.VAR_ENGINESTATE },
			{ "engine.message", CommonScrVar.VAR_ENGINEMESSAGE },
			{ "engine.language", CommonScrVar.VAR_ENGINELANGUAGE },
			{ "engine.onlineActive", CommonScrVar.VAR_ENGINEONLINEACTIVE },
			{ "engine.sfxVolume", CommonScrVar.VAR_ENGINESFXVOLUME },
			{ "engine.bgmVolume", CommonScrVar.VAR_ENGINEBGMVOLUME },
			{ "engine.trialMode", CommonScrVar.VAR_ENGINETRIALMODE },
			{ "engine.deviceType", CommonScrVar.VAR_ENGINEDEVICETYPE },

			// Haptics
			{ "engine.hapticsEnabled", CommonScrVar.VAR_HAPTICSENABLED },
		};

		readonly FuncNameList funcNames = new FuncNameList()
		{
			{ "End", CommonScrFunc.FUNC_END },
			{ "Equal", CommonScrFunc.FUNC_EQUAL },
			{ "Add", CommonScrFunc.FUNC_ADD },
			{ "Sub", CommonScrFunc.FUNC_SUB },
			{ "Inc", CommonScrFunc.FUNC_INC },
			{ "Dec", CommonScrFunc.FUNC_DEC },
			{ "Mul", CommonScrFunc.FUNC_MUL },
			{ "Div", CommonScrFunc.FUNC_DIV },
			{ "ShR", CommonScrFunc.FUNC_SHR },
			{ "ShL", CommonScrFunc.FUNC_SHL },
			{ "And", CommonScrFunc.FUNC_AND },
			{ "Or", CommonScrFunc.FUNC_OR },
			{ "Xor", CommonScrFunc.FUNC_XOR },
			{ "Mod", CommonScrFunc.FUNC_MOD },
			{ "FlipSign", CommonScrFunc.FUNC_FLIPSIGN },

			{ "CheckEqual", CommonScrFunc.FUNC_CHECKEQUAL },
			{ "CheckGreater", CommonScrFunc.FUNC_CHECKGREATER },
			{ "CheckLower", CommonScrFunc.FUNC_CHECKLOWER },
			{ "CheckNotEqual", CommonScrFunc.FUNC_CHECKNOTEQUAL },

			{ "IfEqual", CommonScrFunc.FUNC_IFEQUAL },
			{ "IfGreater", CommonScrFunc.FUNC_IFGREATER },
			{ "IfGreaterOrEqual", CommonScrFunc.FUNC_IFGREATEROREQUAL },
			{ "IfLower", CommonScrFunc.FUNC_IFLOWER },
			{ "IfLowerOrEqual", CommonScrFunc.FUNC_IFLOWEROREQUAL },
			{ "IfNotEqual", CommonScrFunc.FUNC_IFNOTEQUAL },
			{ "else", CommonScrFunc.FUNC_ELSE },
			{ "endif", CommonScrFunc.FUNC_ENDIF },

			{ "WEqual", CommonScrFunc.FUNC_WEQUAL },
			{ "WGreater", CommonScrFunc.FUNC_WGREATER },
			{ "WGreaterOrEqual", CommonScrFunc.FUNC_WGREATEROREQUAL },
			{ "WLower", CommonScrFunc.FUNC_WLOWER },
			{ "WLowerOrEqual", CommonScrFunc.FUNC_WLOWEROREQUAL },
			{ "WNotEqual", CommonScrFunc.FUNC_WNOTEQUAL },
			{ "loop", CommonScrFunc.FUNC_LOOP },

			{ "ForEachActive", CommonScrFunc.FUNC_FOREACHACTIVE },
			{ "ForEachAll", CommonScrFunc.FUNC_FOREACHALL },
			{ "next", CommonScrFunc.FUNC_NEXT },

			{ "switch", CommonScrFunc.FUNC_SWITCH },
			{ "break", CommonScrFunc.FUNC_BREAK },
			{ "endswitch", CommonScrFunc.FUNC_ENDSWITCH },

			// Math Functions
			{ "Rand", CommonScrFunc.FUNC_RAND },
			{ "Sin", CommonScrFunc.FUNC_SIN },
			{ "Cos", CommonScrFunc.FUNC_COS },
			{ "Sin256", CommonScrFunc.FUNC_SIN256 },
			{ "Cos256", CommonScrFunc.FUNC_COS256 },
			{ "ATan2", CommonScrFunc.FUNC_ATAN2 },
			{ "Interpolate", CommonScrFunc.FUNC_INTERPOLATE },
			{ "InterpolateXY", CommonScrFunc.FUNC_INTERPOLATEXY },

			// Graphics Functions
			{ "LoadSpriteSheet", CommonScrFunc.FUNC_LOADSPRITESHEET },
			{ "RemoveSpriteSheet", CommonScrFunc.FUNC_REMOVESPRITESHEET },
			{ "DrawSprite", CommonScrFunc.FUNC_DRAWSPRITE },
			{ "DrawSpriteXY", CommonScrFunc.FUNC_DRAWSPRITEXY },
			{ "DrawSpriteScreenXY", CommonScrFunc.FUNC_DRAWSPRITESCREENXY },
			{ "DrawTintRect", CommonScrFunc.FUNC_DRAWTINTRECT },
			{ "DrawNumbers", CommonScrFunc.FUNC_DRAWNUMBERS },
			{ "DrawActName", CommonScrFunc.FUNC_DRAWACTNAME },
			{ "DrawMenu", CommonScrFunc.FUNC_DRAWMENU },
			{ "SpriteFrame", CommonScrFunc.FUNC_SPRITEFRAME },
			{ "EditFrame", CommonScrFunc.FUNC_EDITFRAME },
			{ "LoadPalette", CommonScrFunc.FUNC_LOADPALETTE },
			{ "RotatePalette", CommonScrFunc.FUNC_ROTATEPALETTE },
			{ "SetScreenFade", CommonScrFunc.FUNC_SETSCREENFADE },
			{ "SetActivePalette", CommonScrFunc.FUNC_SETACTIVEPALETTE },
			{ "SetPaletteFade", CommonScrFunc.FUNC_SETPALETTEFADE },
			{ "SetPaletteEntry", CommonScrFunc.FUNC_SETPALETTEENTRY },
			{ "GetPaletteEntry", CommonScrFunc.FUNC_GETPALETTEENTRY },
			{ "CopyPalette", CommonScrFunc.FUNC_COPYPALETTE },
			{ "ClearScreen", CommonScrFunc.FUNC_CLEARSCREEN },
			{ "DrawSpriteFX", CommonScrFunc.FUNC_DRAWSPRITEFX },
			{ "DrawSpriteScreenFX", CommonScrFunc.FUNC_DRAWSPRITESCREENFX },

			// More Useful Stuff
			{ "LoadAnimation", CommonScrFunc.FUNC_LOADANIMATION },
			{ "SetupMenu", CommonScrFunc.FUNC_SETUPMENU },
			{ "AddMenuEntry", CommonScrFunc.FUNC_ADDMENUENTRY },
			{ "EditMenuEntry", CommonScrFunc.FUNC_EDITMENUENTRY },
			{ "LoadStage", CommonScrFunc.FUNC_LOADSTAGE },
			{ "DrawRect", CommonScrFunc.FUNC_DRAWRECT },
			{ "ResetObjectEntity", CommonScrFunc.FUNC_RESETOBJECTENTITY },
			{ "BoxCollisionTest", CommonScrFunc.FUNC_BOXCOLLISIONTEST },
			{ "CreateTempObject", CommonScrFunc.FUNC_CREATETEMPOBJECT },

			// Player and Animation Functions
			{ "ProcessObjectMovement", CommonScrFunc.FUNC_PROCESSOBJECTMOVEMENT },
			{ "ProcessObjectControl", CommonScrFunc.FUNC_PROCESSOBJECTCONTROL },
			{ "ProcessAnimation", CommonScrFunc.FUNC_PROCESSANIMATION },
			{ "DrawObjectAnimation", CommonScrFunc.FUNC_DRAWOBJECTANIMATION },

			// Music
			{ "SetMusicTrack", CommonScrFunc.FUNC_SETMUSICTRACK },
			{ "PlayMusic", CommonScrFunc.FUNC_PLAYMUSIC },
			{ "StopMusic", CommonScrFunc.FUNC_STOPMUSIC },
			{ "PauseMusic", CommonScrFunc.FUNC_PAUSEMUSIC },
			{ "ResumeMusic", CommonScrFunc.FUNC_RESUMEMUSIC },
			{ "SwapMusicTrack", CommonScrFunc.FUNC_SWAPMUSICTRACK },

			// Sound FX
			{ "PlaySfx", CommonScrFunc.FUNC_PLAYSFX },
			{ "StopSfx", CommonScrFunc.FUNC_STOPSFX },
			{ "SetSfxAttributes", CommonScrFunc.FUNC_SETSFXATTRIBUTES },

			// More Collision Stuff
			{ "ObjectTileCollision", CommonScrFunc.FUNC_OBJECTTILECOLLISION },
			{ "ObjectTileGrip", CommonScrFunc.FUNC_OBJECTTILEGRIP },

			// Bitwise Not
			{ "Not", CommonScrFunc.FUNC_NOT },

			// 3D Stuff
			{ "Draw3DScene", CommonScrFunc.FUNC_DRAW3DSCENE },
			{ "SetIdentityMatrix", CommonScrFunc.FUNC_SETIDENTITYMATRIX },
			{ "MatrixMultiply", CommonScrFunc.FUNC_MATRIXMULTIPLY },
			{ "MatrixTranslateXYZ", CommonScrFunc.FUNC_MATRIXTRANSLATEXYZ },
			{ "MatrixScaleXYZ", CommonScrFunc.FUNC_MATRIXSCALEXYZ },
			{ "MatrixRotateX", CommonScrFunc.FUNC_MATRIXROTATEX },
			{ "MatrixRotateY", CommonScrFunc.FUNC_MATRIXROTATEY },
			{ "MatrixRotateZ", CommonScrFunc.FUNC_MATRIXROTATEZ },
			{ "MatrixRotateXYZ", CommonScrFunc.FUNC_MATRIXROTATEXYZ },
			{ "MatrixInverse", CommonScrFunc.FUNC_MATRIXINVERSE },
			{ "TransformVertices", CommonScrFunc.FUNC_TRANSFORMVERTICES },

			{ "CallFunction", CommonScrFunc.FUNC_CALLFUNCTION },
			{ "return", CommonScrFunc.FUNC_RETURN },

			{ "SetLayerDeformation", CommonScrFunc.FUNC_SETLAYERDEFORMATION },
			{ "CheckTouchRect", CommonScrFunc.FUNC_CHECKTOUCHRECT },
			{ "GetTileLayerEntry", CommonScrFunc.FUNC_GETTILELAYERENTRY },
			{ "SetTileLayerEntry", CommonScrFunc.FUNC_SETTILELAYERENTRY },

			{ "GetBit", CommonScrFunc.FUNC_GETBIT },
			{ "SetBit", CommonScrFunc.FUNC_SETBIT },

			{ "ClearDrawList", CommonScrFunc.FUNC_CLEARDRAWLIST },
			{ "AddDrawListEntityRef", CommonScrFunc.FUNC_ADDDRAWLISTENTITYREF },
			{ "GetDrawListEntityRef", CommonScrFunc.FUNC_GETDRAWLISTENTITYREF },
			{ "SetDrawListEntityRef", CommonScrFunc.FUNC_SETDRAWLISTENTITYREF },

			{ "Get16x16TileInfo", CommonScrFunc.FUNC_GET16X16TILEINFO },
			{ "Set16x16TileInfo", CommonScrFunc.FUNC_SET16X16TILEINFO },
			{ "Copy16x16Tile", CommonScrFunc.FUNC_COPY16X16TILE },
			{ "GetAnimationByName", CommonScrFunc.FUNC_GETANIMATIONBYNAME },
			{ "ReadSaveRAM", CommonScrFunc.FUNC_READSAVERAM },
			{ "WriteSaveRAM", CommonScrFunc.FUNC_WRITESAVERAM },

			{ "LoadFontFile", CommonScrFunc.FUNC_LOADTEXTFONT },
			{ "LoadTextFile", CommonScrFunc.FUNC_LOADTEXTFILE },
			{ "GetTextInfo", CommonScrFunc.FUNC_GETTEXTINFO },
			{ "DrawText", CommonScrFunc.FUNC_DRAWTEXT },
			{ "GetVersionNumber", CommonScrFunc.FUNC_GETVERSIONNUMBER },

			{ "GetTableValue", CommonScrFunc.FUNC_GETTABLEVALUE },
			{ "SetTableValue", CommonScrFunc.FUNC_SETTABLEVALUE },

			{ "CheckCurrentStageFolder", CommonScrFunc.FUNC_CHECKCURRENTSTAGEFOLDER },
			{ "Abs", CommonScrFunc.FUNC_ABS },

			{ "CallNativeFunction", CommonScrFunc.FUNC_CALLNATIVEFUNCTION },
			{ "CallNativeFunction2", CommonScrFunc.FUNC_CALLNATIVEFUNCTION2 },
			{ "CallNativeFunction4", CommonScrFunc.FUNC_CALLNATIVEFUNCTION4 },

			{ "SetObjectRange", CommonScrFunc.FUNC_SETOBJECTRANGE },
			{ "GetObjectValue", CommonScrFunc.FUNC_GETOBJECTVALUE },
			{ "SetObjectValue", CommonScrFunc.FUNC_SETOBJECTVALUE },
			{ "CopyObject", CommonScrFunc.FUNC_COPYOBJECT },
			{ "Print", CommonScrFunc.FUNC_PRINT },
		};

		private MaybeVarRef GetVarRef(string value)
		{
			MaybeVarRef index = null;
			int indstart = value.IndexOf('[');
			if (indstart != -1)
			{
				int indend = value.IndexOf(']', indstart);
				if (indend != -1)
				{
					index = GetVarRef(value.Substring(indstart + 1, indend - indstart - 1));
					value = value.Remove(indstart, indend - indstart + 1);
				}
			}
			if (varNames.TryGetValue(value, out CommonScrVar var))
				return new MaybeVarRef(var, value, index);
			else
				return new MaybeVarRef(null, value, index);
		}

		readonly Dictionary<CommonScrVar, CommonScrVar> playerVarDict = new Dictionary<CommonScrVar, CommonScrVar>()
		{
			{ CommonScrVar.VAR_PLAYERSTATE, CommonScrVar.VAR_OBJECTSTATE },
			{ CommonScrVar.VAR_PLAYERCONTROLMODE, CommonScrVar.VAR_OBJECTCONTROLMODE },
			{ CommonScrVar.VAR_PLAYERCONTROLLOCK, CommonScrVar.VAR_OBJECTCONTROLLOCK },
			{ CommonScrVar.VAR_PLAYERCOLLISIONMODE, CommonScrVar.VAR_OBJECTCOLLISIONMODE },
			{ CommonScrVar.VAR_PLAYERCOLLISIONPLANE, CommonScrVar.VAR_OBJECTCOLLISIONPLANE },
			{ CommonScrVar.VAR_PLAYERXPOS, CommonScrVar.VAR_OBJECTXPOS },
			{ CommonScrVar.VAR_PLAYERYPOS, CommonScrVar.VAR_OBJECTYPOS },
			{ CommonScrVar.VAR_PLAYERIXPOS, CommonScrVar.VAR_OBJECTIXPOS },
			{ CommonScrVar.VAR_PLAYERIYPOS, CommonScrVar.VAR_OBJECTIYPOS },
			{ CommonScrVar.VAR_PLAYERSPEED, CommonScrVar.VAR_OBJECTSPEED },
			{ CommonScrVar.VAR_PLAYERXVELOCITY, CommonScrVar.VAR_OBJECTXVEL },
			{ CommonScrVar.VAR_PLAYERYVELOCITY, CommonScrVar.VAR_OBJECTYVEL },
			{ CommonScrVar.VAR_PLAYERGRAVITY, CommonScrVar.VAR_OBJECTGRAVITY },
			{ CommonScrVar.VAR_PLAYERANGLE, CommonScrVar.VAR_OBJECTANGLE },
			{ CommonScrVar.VAR_PLAYERPUSHING, CommonScrVar.VAR_OBJECTPUSHING },
			{ CommonScrVar.VAR_PLAYERTRACKSCROLL, CommonScrVar.VAR_OBJECTSCROLLTRACKING },
			{ CommonScrVar.VAR_PLAYERUP, CommonScrVar.VAR_OBJECTUP },
			{ CommonScrVar.VAR_PLAYERDOWN, CommonScrVar.VAR_OBJECTDOWN },
			{ CommonScrVar.VAR_PLAYERLEFT, CommonScrVar.VAR_OBJECTLEFT },
			{ CommonScrVar.VAR_PLAYERRIGHT, CommonScrVar.VAR_OBJECTRIGHT },
			{ CommonScrVar.VAR_PLAYERJUMPPRESS, CommonScrVar.VAR_OBJECTJUMPPRESS },
			{ CommonScrVar.VAR_PLAYERJUMPHOLD, CommonScrVar.VAR_OBJECTJUMPHOLD },
			{ CommonScrVar.VAR_PLAYERENTITYNO, CommonScrVar.VAR_OBJECTENTITYPOS },
			{ CommonScrVar.VAR_PLAYERCOLLISIONLEFT, CommonScrVar.VAR_OBJECTCOLLISIONLEFT },
			{ CommonScrVar.VAR_PLAYERCOLLISIONTOP, CommonScrVar.VAR_OBJECTCOLLISIONTOP },
			{ CommonScrVar.VAR_PLAYERCOLLISIONRIGHT, CommonScrVar.VAR_OBJECTCOLLISIONRIGHT },
			{ CommonScrVar.VAR_PLAYERCOLLISIONBOTTOM, CommonScrVar.VAR_OBJECTCOLLISIONBOTTOM },
			{ CommonScrVar.VAR_PLAYERTILECOLLISIONS, CommonScrVar.VAR_OBJECTTILECOLLISIONS },
			{ CommonScrVar.VAR_PLAYERVISIBLE, CommonScrVar.VAR_OBJECTVISIBLE },
			{ CommonScrVar.VAR_PLAYERROTATION, CommonScrVar.VAR_OBJECTROTATION },
			{ CommonScrVar.VAR_PLAYERSCALE, CommonScrVar.VAR_OBJECTSCALE },
			{ CommonScrVar.VAR_PLAYERPRIORITY, CommonScrVar.VAR_OBJECTPRIORITY },
			{ CommonScrVar.VAR_PLAYERDRAWORDER, CommonScrVar.VAR_OBJECTDRAWORDER },
			{ CommonScrVar.VAR_PLAYERDIRECTION, CommonScrVar.VAR_OBJECTDIRECTION },
			{ CommonScrVar.VAR_PLAYERINKEFFECT, CommonScrVar.VAR_OBJECTINKEFFECT },
			{ CommonScrVar.VAR_PLAYERALPHA, CommonScrVar.VAR_OBJECTALPHA },
			{ CommonScrVar.VAR_PLAYERFRAME, CommonScrVar.VAR_OBJECTFRAME },
			{ CommonScrVar.VAR_PLAYERANIMATION, CommonScrVar.VAR_OBJECTANIMATION },
			{ CommonScrVar.VAR_PLAYERPREVANIMATION, CommonScrVar.VAR_OBJECTPREVANIMATION },
			{ CommonScrVar.VAR_PLAYERANIMATIONSPEED, CommonScrVar.VAR_OBJECTANIMATIONSPEED },
			{ CommonScrVar.VAR_PLAYERANIMATIONTIMER, CommonScrVar.VAR_OBJECTANIMATIONTIMER },
			{ CommonScrVar.VAR_PLAYERVALUE0, CommonScrVar.VAR_OBJECTVALUE0 },
			{ CommonScrVar.VAR_PLAYERVALUE1, CommonScrVar.VAR_OBJECTVALUE1 },
			{ CommonScrVar.VAR_PLAYERVALUE2, CommonScrVar.VAR_OBJECTVALUE2 },
			{ CommonScrVar.VAR_PLAYERVALUE3, CommonScrVar.VAR_OBJECTVALUE3 },
			{ CommonScrVar.VAR_PLAYERVALUE4, CommonScrVar.VAR_OBJECTVALUE4 },
			{ CommonScrVar.VAR_PLAYERVALUE5, CommonScrVar.VAR_OBJECTVALUE5 },
			{ CommonScrVar.VAR_PLAYERVALUE6, CommonScrVar.VAR_OBJECTVALUE6 },
			{ CommonScrVar.VAR_PLAYERVALUE7, CommonScrVar.VAR_OBJECTVALUE7 },
			{ CommonScrVar.VAR_PLAYERVALUE8, CommonScrVar.VAR_OBJECTVALUE8 },
			{ CommonScrVar.VAR_PLAYERVALUE9, CommonScrVar.VAR_OBJECTVALUE9 },
			{ CommonScrVar.VAR_PLAYERVALUE10, CommonScrVar.VAR_OBJECTVALUE10 },
			{ CommonScrVar.VAR_PLAYERVALUE11, CommonScrVar.VAR_OBJECTVALUE11 },
			{ CommonScrVar.VAR_PLAYERVALUE12, CommonScrVar.VAR_OBJECTVALUE12 },
			{ CommonScrVar.VAR_PLAYERVALUE13, CommonScrVar.VAR_OBJECTVALUE13 },
			{ CommonScrVar.VAR_PLAYERVALUE14, CommonScrVar.VAR_OBJECTVALUE14 },
			{ CommonScrVar.VAR_PLAYERVALUE15, CommonScrVar.VAR_OBJECTVALUE15 },
			{ CommonScrVar.VAR_PLAYEROUTOFBOUNDS, CommonScrVar.VAR_OBJECTOUTOFBOUNDS },
		};

		private string GetVarText(MaybeVarRef varRef, System.IO.TextWriter writer)
		{
			string name = varRef.Text;
			CommonScrVar? variable = varRef.Variable;
			MaybeVarRef index = varRef.Index;
			if (variable.HasValue)
			{
				if (varNames.TryGetValue(variable.Value, out string _name))
					name = _name;
				else if (writer != null)
				{
					writer.WriteLine("// WARNING: Variable {0} does not exist in RSDKv4!", variable.Value);
					if (playerVarDict.TryGetValue(variable.Value, out CommonScrVar newvar))
					{
						variable = newvar;
						name = varNames[newvar];
						index = new MaybeVarRef(null, "0", null);
					}
				}
			}
			if (index != null)
			{
				string indexstr = GetVarText(index, writer);
				int ins = name.Length;
				if (variable.HasValue)
					switch (variable.Value)
					{
						case CommonScrVar.VAR_OBJECTENTITYPOS:
						case CommonScrVar.VAR_OBJECTGROUPID:
						case CommonScrVar.VAR_OBJECTTYPE:
						case CommonScrVar.VAR_OBJECTPROPERTYVALUE:
						case CommonScrVar.VAR_OBJECTXPOS:
						case CommonScrVar.VAR_OBJECTYPOS:
						case CommonScrVar.VAR_OBJECTIXPOS:
						case CommonScrVar.VAR_OBJECTIYPOS:
						case CommonScrVar.VAR_OBJECTXVEL:
						case CommonScrVar.VAR_OBJECTYVEL:
						case CommonScrVar.VAR_OBJECTSPEED:
						case CommonScrVar.VAR_OBJECTSTATE:
						case CommonScrVar.VAR_OBJECTROTATION:
						case CommonScrVar.VAR_OBJECTSCALE:
						case CommonScrVar.VAR_OBJECTPRIORITY:
						case CommonScrVar.VAR_OBJECTDRAWORDER:
						case CommonScrVar.VAR_OBJECTDIRECTION:
						case CommonScrVar.VAR_OBJECTINKEFFECT:
						case CommonScrVar.VAR_OBJECTALPHA:
						case CommonScrVar.VAR_OBJECTFRAME:
						case CommonScrVar.VAR_OBJECTANIMATION:
						case CommonScrVar.VAR_OBJECTPREVANIMATION:
						case CommonScrVar.VAR_OBJECTANIMATIONSPEED:
						case CommonScrVar.VAR_OBJECTANIMATIONTIMER:
						case CommonScrVar.VAR_OBJECTANGLE:
						case CommonScrVar.VAR_OBJECTLOOKPOSX:
						case CommonScrVar.VAR_OBJECTLOOKPOSY:
						case CommonScrVar.VAR_OBJECTCOLLISIONMODE:
						case CommonScrVar.VAR_OBJECTCOLLISIONPLANE:
						case CommonScrVar.VAR_OBJECTCONTROLMODE:
						case CommonScrVar.VAR_OBJECTCONTROLLOCK:
						case CommonScrVar.VAR_OBJECTPUSHING:
						case CommonScrVar.VAR_OBJECTVISIBLE:
						case CommonScrVar.VAR_OBJECTTILECOLLISIONS:
						case CommonScrVar.VAR_OBJECTINTERACTION:
						case CommonScrVar.VAR_OBJECTGRAVITY:
						case CommonScrVar.VAR_OBJECTUP:
						case CommonScrVar.VAR_OBJECTDOWN:
						case CommonScrVar.VAR_OBJECTLEFT:
						case CommonScrVar.VAR_OBJECTRIGHT:
						case CommonScrVar.VAR_OBJECTJUMPPRESS:
						case CommonScrVar.VAR_OBJECTJUMPHOLD:
						case CommonScrVar.VAR_OBJECTSCROLLTRACKING:
						case CommonScrVar.VAR_OBJECTFLOORSENSORL:
						case CommonScrVar.VAR_OBJECTFLOORSENSORC:
						case CommonScrVar.VAR_OBJECTFLOORSENSORR:
						case CommonScrVar.VAR_OBJECTFLOORSENSORLC:
						case CommonScrVar.VAR_OBJECTFLOORSENSORRC:
						case CommonScrVar.VAR_OBJECTCOLLISIONLEFT:
						case CommonScrVar.VAR_OBJECTCOLLISIONTOP:
						case CommonScrVar.VAR_OBJECTCOLLISIONRIGHT:
						case CommonScrVar.VAR_OBJECTCOLLISIONBOTTOM:
						case CommonScrVar.VAR_OBJECTOUTOFBOUNDS:
						case CommonScrVar.VAR_OBJECTSPRITESHEET:
						case CommonScrVar.VAR_OBJECTVALUE0:
						case CommonScrVar.VAR_OBJECTVALUE1:
						case CommonScrVar.VAR_OBJECTVALUE2:
						case CommonScrVar.VAR_OBJECTVALUE3:
						case CommonScrVar.VAR_OBJECTVALUE4:
						case CommonScrVar.VAR_OBJECTVALUE5:
						case CommonScrVar.VAR_OBJECTVALUE6:
						case CommonScrVar.VAR_OBJECTVALUE7:
						case CommonScrVar.VAR_OBJECTVALUE8:
						case CommonScrVar.VAR_OBJECTVALUE9:
						case CommonScrVar.VAR_OBJECTVALUE10:
						case CommonScrVar.VAR_OBJECTVALUE11:
						case CommonScrVar.VAR_OBJECTVALUE12:
						case CommonScrVar.VAR_OBJECTVALUE13:
						case CommonScrVar.VAR_OBJECTVALUE14:
						case CommonScrVar.VAR_OBJECTVALUE15:
						case CommonScrVar.VAR_OBJECTVALUE16:
						case CommonScrVar.VAR_OBJECTVALUE17:
						case CommonScrVar.VAR_OBJECTVALUE18:
						case CommonScrVar.VAR_OBJECTVALUE19:
						case CommonScrVar.VAR_OBJECTVALUE20:
						case CommonScrVar.VAR_OBJECTVALUE21:
						case CommonScrVar.VAR_OBJECTVALUE22:
						case CommonScrVar.VAR_OBJECTVALUE23:
						case CommonScrVar.VAR_OBJECTVALUE24:
						case CommonScrVar.VAR_OBJECTVALUE25:
						case CommonScrVar.VAR_OBJECTVALUE26:
						case CommonScrVar.VAR_OBJECTVALUE27:
						case CommonScrVar.VAR_OBJECTVALUE28:
						case CommonScrVar.VAR_OBJECTVALUE29:
						case CommonScrVar.VAR_OBJECTVALUE30:
						case CommonScrVar.VAR_OBJECTVALUE31:
						case CommonScrVar.VAR_OBJECTVALUE32:
						case CommonScrVar.VAR_OBJECTVALUE33:
						case CommonScrVar.VAR_OBJECTVALUE34:
						case CommonScrVar.VAR_OBJECTVALUE35:
						case CommonScrVar.VAR_OBJECTVALUE36:
						case CommonScrVar.VAR_OBJECTVALUE37:
						case CommonScrVar.VAR_OBJECTVALUE38:
						case CommonScrVar.VAR_OBJECTVALUE39:
						case CommonScrVar.VAR_OBJECTVALUE40:
						case CommonScrVar.VAR_OBJECTVALUE41:
						case CommonScrVar.VAR_OBJECTVALUE42:
						case CommonScrVar.VAR_OBJECTVALUE43:
						case CommonScrVar.VAR_OBJECTVALUE44:
						case CommonScrVar.VAR_OBJECTVALUE45:
						case CommonScrVar.VAR_OBJECTVALUE46:
						case CommonScrVar.VAR_OBJECTVALUE47:
						case CommonScrVar.VAR_TOUCHSCREENDOWN:
						case CommonScrVar.VAR_TOUCHSCREENXPOS:
						case CommonScrVar.VAR_TOUCHSCREENYPOS:
						case CommonScrVar.VAR_KEYDOWNUP:
						case CommonScrVar.VAR_KEYDOWNDOWN:
						case CommonScrVar.VAR_KEYDOWNLEFT:
						case CommonScrVar.VAR_KEYDOWNRIGHT:
						case CommonScrVar.VAR_KEYDOWNBUTTONA:
						case CommonScrVar.VAR_KEYDOWNBUTTONB:
						case CommonScrVar.VAR_KEYDOWNBUTTONC:
						case CommonScrVar.VAR_KEYDOWNBUTTONX:
						case CommonScrVar.VAR_KEYDOWNBUTTONY:
						case CommonScrVar.VAR_KEYDOWNBUTTONZ:
						case CommonScrVar.VAR_KEYDOWNBUTTONL:
						case CommonScrVar.VAR_KEYDOWNBUTTONR:
						case CommonScrVar.VAR_KEYDOWNSTART:
						case CommonScrVar.VAR_KEYDOWNSELECT:
						case CommonScrVar.VAR_KEYPRESSUP:
						case CommonScrVar.VAR_KEYPRESSDOWN:
						case CommonScrVar.VAR_KEYPRESSLEFT:
						case CommonScrVar.VAR_KEYPRESSRIGHT:
						case CommonScrVar.VAR_KEYPRESSBUTTONA:
						case CommonScrVar.VAR_KEYPRESSBUTTONB:
						case CommonScrVar.VAR_KEYPRESSBUTTONC:
						case CommonScrVar.VAR_KEYPRESSBUTTONX:
						case CommonScrVar.VAR_KEYPRESSBUTTONY:
						case CommonScrVar.VAR_KEYPRESSBUTTONZ:
						case CommonScrVar.VAR_KEYPRESSBUTTONL:
						case CommonScrVar.VAR_KEYPRESSBUTTONR:
						case CommonScrVar.VAR_KEYPRESSSTART:
						case CommonScrVar.VAR_KEYPRESSSELECT:
						case CommonScrVar.VAR_TILELAYERXSIZE:
						case CommonScrVar.VAR_TILELAYERYSIZE:
						case CommonScrVar.VAR_TILELAYERTYPE:
						case CommonScrVar.VAR_TILELAYERANGLE:
						case CommonScrVar.VAR_TILELAYERXPOS:
						case CommonScrVar.VAR_TILELAYERYPOS:
						case CommonScrVar.VAR_TILELAYERZPOS:
						case CommonScrVar.VAR_TILELAYERPARALLAXFACTOR:
						case CommonScrVar.VAR_TILELAYERSCROLLSPEED:
						case CommonScrVar.VAR_TILELAYERSCROLLPOS:
						case CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSET:
						case CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSETW:
						case CommonScrVar.VAR_HPARALLAXPARALLAXFACTOR:
						case CommonScrVar.VAR_HPARALLAXSCROLLSPEED:
						case CommonScrVar.VAR_HPARALLAXSCROLLPOS:
						case CommonScrVar.VAR_VPARALLAXPARALLAXFACTOR:
						case CommonScrVar.VAR_VPARALLAXSCROLLSPEED:
						case CommonScrVar.VAR_VPARALLAXSCROLLPOS:
						case CommonScrVar.VAR_VERTEXBUFFERX:
						case CommonScrVar.VAR_VERTEXBUFFERY:
						case CommonScrVar.VAR_VERTEXBUFFERZ:
						case CommonScrVar.VAR_VERTEXBUFFERU:
						case CommonScrVar.VAR_VERTEXBUFFERV:
						case CommonScrVar.VAR_FACEBUFFERA:
						case CommonScrVar.VAR_FACEBUFFERB:
						case CommonScrVar.VAR_FACEBUFFERC:
						case CommonScrVar.VAR_FACEBUFFERD:
						case CommonScrVar.VAR_FACEBUFFERFLAG:
						case CommonScrVar.VAR_FACEBUFFERCOLOR:
						case CommonScrVar.VAR_CAMERAENABLED:
						case CommonScrVar.VAR_CAMERATARGET:
						case CommonScrVar.VAR_CAMERASTYLE:
						case CommonScrVar.VAR_CAMERAXPOS:
						case CommonScrVar.VAR_CAMERAYPOS:
						case CommonScrVar.VAR_CAMERAADJUSTY:
							ins = name.IndexOf('.');
							break;
					}
				return name.Insert(ins, $"[{indexstr}]");
			}
			return name;
		}

		public override List<ScriptLine> ReadScript(string filename)
		{
			List<ScriptLine> result = new List<ScriptLine>();

			using (var filestr = System.IO.File.OpenRead(filename))
			{
				ScriptReadModes readMode = READMODE_NORMAL;
				ScriptParseModes parseMode = PARSEMODE_SCOPELESS;
				char prevChar = '\0';
				char curChar = '\0';

				while (readMode < READMODE_EOF)
				{
					readMode = READMODE_NORMAL;
					StringBuilder scriptTextBuf = new StringBuilder();
					StringBuilder comment = new StringBuilder();

					while (readMode < READMODE_ENDLINE)
					{
						prevChar = curChar;
						curChar = (char)filestr.ReadByte();

						if (readMode == READMODE_COMMENTLINE)
						{
							if (curChar == '\n')
								readMode = READMODE_ENDLINE;
							else if (curChar != '\r')
								comment.Append(curChar);
						}
						if (readMode == READMODE_STRING)
						{
							if (curChar == '\t' || curChar == '\r' || curChar == '\n' || curChar == ';' || readMode >= READMODE_COMMENTLINE)
							{
								if ((curChar == '\n' && prevChar != '\r') || (curChar == '\n' && prevChar == '\r'))
								{
									readMode = READMODE_ENDLINE;
								}
							}
							else if (curChar != '/' || scriptTextBuf.Length <= 0)
							{
								scriptTextBuf.Append(curChar);
								if (curChar == '"')
									readMode = READMODE_NORMAL;
							}
							else if (curChar == '/' && prevChar == '/')
							{
								readMode = READMODE_COMMENTLINE;
								scriptTextBuf.Remove(scriptTextBuf.Length - 1, 1);
							}
							else
							{
								scriptTextBuf.Append(curChar);
							}
						}
						else if (readMode == READMODE_NAME)
						{
							if (curChar == '\r' || curChar == '\n' || curChar == ';' || readMode >= READMODE_COMMENTLINE)
							{
								if ((curChar == '\n' && prevChar != '\r') || (curChar == '\n' && prevChar == '\r') || curChar == ';')
								{
									readMode = READMODE_ENDLINE;
								}
							}
							else if (curChar != '/' || scriptTextBuf.Length <= 0)
							{
								scriptTextBuf.Append(curChar);
								if (curChar == ']')
									readMode = READMODE_NORMAL;
							}
							else if (curChar == '/' && prevChar == '/')
							{
								readMode = READMODE_COMMENTLINE;
								scriptTextBuf.Remove(scriptTextBuf.Length - 1, 1);
							}
							else
							{
								scriptTextBuf.Append(curChar);
							}
						}
						else if (curChar == ' ' || curChar == '\t' || curChar == '\r' || curChar == '\n' || curChar == ';'
								 || readMode >= READMODE_COMMENTLINE)
						{
							if ((curChar == '\n' && prevChar != '\r') || (curChar == '\n' && prevChar == '\r') || curChar == ';')
							{
								readMode = READMODE_ENDLINE;
							}
						}
						else if (curChar != '/' || scriptTextBuf.Length <= 0)
						{
							scriptTextBuf.Append(curChar);
							if (curChar == '"' && readMode != READMODE_NORMAL)
								readMode = READMODE_STRING;

							if (curChar == '[' && readMode == READMODE_NORMAL)
							{
								string tmp = scriptTextBuf.ToString();
								if (tmp.EndsWith("TypeName[") || tmp.EndsWith("SfxName[") || tmp.EndsWith("AchievementName[") || tmp.EndsWith("PlayerName[") || tmp.EndsWith("StageName["))
									readMode = READMODE_NAME;
							}
						}
						else if (curChar == '/' && prevChar == '/')
						{
							readMode = READMODE_COMMENTLINE;
							scriptTextBuf.Remove(scriptTextBuf.Length - 1, 1);
						}
						else
						{
							scriptTextBuf.Append(curChar);
						}

						if (filestr.Position >= filestr.Length)
						{
							readMode = READMODE_EOF;
						}
					}

					string scriptText = scriptTextBuf.ToString();
					ScriptLine line = null;

					switch (parseMode)
					{
						case PARSEMODE_SCOPELESS:
							if (scriptText.StartsWith("publicalias"))
							{
								int split = scriptText.IndexOf(':');
								line = new ScriptLineAlias(true, scriptText.Substring(split + 1), GetVarRef(scriptText.Substring(11, split - 11)));
							}
							else if (scriptText.StartsWith("privatealias"))
							{
								int split = scriptText.IndexOf(':');
								line = new ScriptLineAlias(false, scriptText.Substring(split + 1), GetVarRef(scriptText.Substring(12, split - 12)));
							}
							else if (scriptText.StartsWith("publicvalue"))
							{
								int split = scriptText.IndexOf('=');
								if (split != -1)
									line = new ScriptLineValue(true, scriptText.Substring(11, split - 11), scriptText.Substring(split + 1));
								else
									line = new ScriptLineValue(true, scriptText.Substring(11), null);
							}
							else if (scriptText.StartsWith("privatevalue"))
							{
								int split = scriptText.IndexOf('=');
								if (split != -1)
									line = new ScriptLineValue(false, scriptText.Substring(12, split - 12), scriptText.Substring(split + 1));
								else
									line = new ScriptLineValue(false, scriptText.Substring(12), null);
							}

							else if (scriptText.StartsWith("publictable"))
							{
								line = new ScriptLineTable(true, scriptText.Substring(11));
								parseMode = PARSEMODE_TABLEREAD;
							}
							else if (scriptText.StartsWith("privatetable"))
							{
								line = new ScriptLineTable(false, scriptText.Substring(12));
								parseMode = PARSEMODE_TABLEREAD;
							}

							else if (scriptText.Equals("eventObjectMain", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineObjectUpdate();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.Equals("eventObjectDraw", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineObjectDraw();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.Equals("eventObjectStartup", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineObjectStartup();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.Equals("eventRSDKDraw", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineRSDKDraw();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.Equals("eventRSDKLoad", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineRSDKLoad();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.StartsWith("reservefunction"))
							{ // forward decl
								line = new ScriptLineReserveFunction(scriptText.Substring(15));

								parseMode = PARSEMODE_SCOPELESS;
							}
							else if (scriptText.StartsWith("function"))
							{ // regular public decl
								line = new ScriptLineFunction(true, scriptText.Substring(8));
								parseMode = PARSEMODE_FUNCTION;
							}
							break;

						case PARSEMODE_FUNCTION:
							if (scriptText.Length > 0)
							{
								if (scriptText.Equals("endevent", StringComparison.OrdinalIgnoreCase))
								{
									line = new ScriptLineEndEvent();
									parseMode = PARSEMODE_SCOPELESS;
								}
								else if (scriptText.Equals("endfunction", StringComparison.OrdinalIgnoreCase))
								{
									line = new ScriptLineEndFunction();
									parseMode = PARSEMODE_SCOPELESS;
								}
								else if (scriptText.StartsWith("#platform:"))
								{
									line = new ScriptLinePlatform(scriptText.Substring(10));
								}
								else if (scriptText.StartsWith("#endplatform"))
								{
									line = new ScriptLineEndPlatform();
								}
								else
								{
									if (scriptText.StartsWith("if"))
									{
										int strPos = 0;
										string compareOp = null;
										foreach (string tok in conditionalTokens)
										{
											int destStrPos = scriptText.IndexOf(tok);
											if (destStrPos > -1)
											{
												strPos = destStrPos;
												compareOp = tok;
											}
										}

										if (compareOp != null)
											line = new ScriptLineIf(compareOp, GetVarRef(scriptText.Substring(2, strPos - 2).Replace("(", "").Replace(")", "").Replace("=", "")), GetVarRef(scriptText.Substring(strPos + compareOp.Length).Replace("(", "").Replace(")", "").Replace("=", "")));
									}
									else if (scriptText.StartsWith("while"))
									{
										int strPos = 0;
										string compareOp = null;
										foreach (string tok in conditionalTokens)
										{
											int destStrPos = scriptText.IndexOf(tok);
											if (destStrPos > -1)
											{
												strPos = destStrPos;
												compareOp = tok;
											}
										}

										if (compareOp != null)
											line = new ScriptLineIf(compareOp, GetVarRef(scriptText.Substring(5, strPos - 5).Replace("(", "").Replace(")", "").Replace("=", "")), GetVarRef(scriptText.Substring(strPos + compareOp.Length).Replace("(", "").Replace(")", "").Replace("=", "")));
									}
									else if (FindStringToken(scriptText, "foreach", 1) == 0)
									{
										string[] split = scriptText.Substring(7).Split(',');

										if (split.Length > 2)
										{
											for (int i = 0; i < 3; i++)
												split[i] = split[i].Replace("(", "").Replace(")", "");
											line = new ScriptLineForEach(GetVarRef(split[0]), GetVarRef(split[1]), split[2]);
										}
									}
									else if (scriptText.StartsWith("switch"))
									{
										line = new ScriptLineSwitch(GetVarRef(scriptText.Substring(6).Replace("(", "").Replace(")", "").Replace("=", "")));
									}
									else if (scriptText.StartsWith("case"))
									{
										line = new ScriptLineCase(scriptText.Substring(4).Replace(":", ""));
									}
									else if (scriptText.StartsWith("default"))
									{
										line = new ScriptLineDefault();
									}
									else if (scriptText.StartsWith("endswitch"))
									{
										line = new ScriptLineEndSwitch();
									}
									else
									{
										string op = null;
										int opInd = -1;
										foreach (string tok in arithmeticTokens)
										{
											int i = scriptText.IndexOf(tok);
											if (i != -1)
											{
												op = tok;
												opInd = i;
											}
										}
										if (op != null)
										{
											line = new ScriptLineArithmetic(op, GetVarRef(scriptText.Substring(0, opInd)), GetVarRef(scriptText.Substring(opInd + op.Length)));
										}
										else
										{
											int i = scriptText.IndexOf('(');
											if (i != -1)
											{
												string funcname = scriptText.Substring(0, i);
												string[] args = scriptText.Substring(i + 1).Replace("(", "").Replace(")", "").Split(',');
												if (funcNames.TryGetValue(funcname, out CommonScrFunc func))
													line = new ScriptLineFunctionCall(func, args.Select(a => GetVarRef(a)).ToArray());
											}
											else if (funcNames.TryGetValue(scriptText, out CommonScrFunc func))
												line = new ScriptLineFunctionCall(func);
										}
									}
								}
							}
							break;

						case PARSEMODE_TABLEREAD:

							if (scriptText.StartsWith("endtable"))
							{
								line = new ScriptLineEndTable();
								parseMode = PARSEMODE_SCOPELESS;
							}
							else
							{
								if (scriptText.Length > 0)
									line = new ScriptLineTableValues(scriptText.Split(',').Where(a => a.Length > 0).ToArray());
							}
							break;

						default: break;
					}
					if (line == null)
						line = new ScriptLineEmpty();
					line.Comment = comment.ToString();
					result.Add(line);
				}
			}

			return result;
		}

		public override void WriteScript(string filename, List<ScriptLine> scriptLines)
		{
			string indent = string.Empty;
			int? tablesize = null;
			using (var writer = System.IO.File.CreateText(filename))
				foreach (var line in scriptLines)
				{
					switch (line)
					{
						case ScriptLineEmpty _:
							if (!string.IsNullOrEmpty(line.Comment))
								writer.Write(indent);
							break;
						case ScriptLineAlias alias:
							writer.Write("{0} alias {1} : {2}", alias.Public ? "public" : "private", GetVarText(alias.Value, writer), alias.Name);
							break;
						case ScriptLineValue value:
							writer.Write("{0} value {1} = {2}", value.Public ? "public" : "private", value.Name, value.Value);
							break;
						case ScriptLineTable table:
							if (table.Size != null)
							{
								writer.WriteLine("// Converting table with size {0}", table.Size);
								tablesize = int.Parse(table.Size);
							}
							writer.Write("{0} table {1}", table.Public ? "public" : "private", table.Name);
							break;
						case ScriptLineTableValues tablevalues:
							writer.Write("\t{0}", string.Join(", ", tablevalues.Values));
							break;
						case ScriptLineEndTable _:
							writer.Write("end table");
							break;
						case ScriptLineObjectUpdate _:
							writer.Write("event ObjectMain");
							indent += '\t';
							break;
						case ScriptLineObjectPlayerInteraction _:
							writer.WriteLine("// WARNING: ObjectPlayerInteraction is not supported in RSDKv4!");
							writer.Write("event ObjectPlayerInteraction");
							indent += '\t';
							break;
						case ScriptLineObjectDraw _:
							writer.Write("event ObjectDraw");
							indent += '\t';
							break;
						case ScriptLineObjectStartup _:
							writer.Write("event ObjectStartup");
							indent += '\t';
							break;
						case ScriptLineRSDKDraw _:
							writer.Write("event RSDKDraw");
							indent += '\t';
							break;
						case ScriptLineRSDKLoad _:
							writer.Write("event RSDKLoad");
							indent += '\t';
							break;
						case ScriptLineReserveFunction reservefunction:
							writer.Write("reserve function {0}", reservefunction.Name);
							break;
						case ScriptLineFunction function:
							if (!function.Public)
								writer.WriteLine("// WARNING: Private functions are not supported in RSDKv4Old!");
							writer.Write("function {0}", function.Name);
							indent += '\t';
							break;
						case ScriptLineEndEvent _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("end event");
							break;
						case ScriptLineEndFunction _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("end function");
							break;
						case ScriptLinePlatform platform:
							writer.Write("#platform: {0}", platform.Platform);
							break;
						case ScriptLineEndPlatform _:
							writer.Write("#endplatform");
							break;
						case ScriptLineIf _if:
							writer.Write("{0}if {1} {2} {3}", indent, GetVarText(_if.Left, writer), _if.Comparison, GetVarText(_if.Right, writer));
							indent += '\t';
							break;
						case ScriptLineWhile _while:
							writer.Write("{0}while {1} {2} {3}", indent, GetVarText(_while.Left, writer), _while.Comparison, GetVarText(_while.Right, writer));
							indent += '\t';
							break;
						case ScriptLineForEach _foreach:
							writer.Write("{0}foreach ({1}, {2}, {3})", indent, GetVarText(_foreach.Type, writer), GetVarText(_foreach.Destination, writer), _foreach.Group);
							indent += '\t';
							break;
						case ScriptLineSwitch _switch:
							writer.Write("{0}switch {1}", indent, GetVarText(_switch.Variable, writer));
							indent += '\t';
							break;
						case ScriptLineCase _case:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("{0}case {1}", indent, _case.Value);
							indent += '\t';
							break;
						case ScriptLineDefault _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("{0}default", indent);
							indent += '\t';
							break;
						case ScriptLineEndSwitch _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("{0}end switch", indent);
							break;
						case ScriptLineArithmetic arithmetic:
							switch (arithmetic.Operator)
							{
								case "++":
								case "--":
									writer.Write("{0}{1}{2}", indent, GetVarText(arithmetic.Left, writer), arithmetic.Operator);
									break;
								default:
									writer.Write("{0}{1} {2} {3}", indent, GetVarText(arithmetic.Left, writer), arithmetic.Operator, GetVarText(arithmetic.Right, writer));
									break;
							}
							break;
						case ScriptLineFunctionCall functioncall:
							if (!funcNames.Contains(functioncall.Function))
							{
								writer.WriteLine("// WARNING: Function {0} does not exist in RSDKv4!", functioncall.Function);
								writer.WriteLine("// Arguments: {0}", string.Join(", ", functioncall.Arguments.Select(a => GetVarText(a, writer))));
							}
							else
							{
								switch (functioncall.Function)
								{
									case CommonScrFunc.FUNC_ELSE:
										if (indent.Length > 0)
											indent = indent.Substring(1);
										writer.Write("{0}{1}", indent, funcNames[functioncall.Function]);
										indent += '\t';
										break;
									case CommonScrFunc.FUNC_ENDIF:
										if (indent.Length > 0)
											indent = indent.Substring(1);
										writer.Write("{0}end if", indent);
										break;
									case CommonScrFunc.FUNC_LOOP:
									case CommonScrFunc.FUNC_NEXT:
										if (indent.Length > 0)
											indent = indent.Substring(1);
										writer.Write("{0}{1}", indent, funcNames[functioncall.Function]);
										break;
									case CommonScrFunc.FUNC_END:
									case CommonScrFunc.FUNC_BREAK:
									case CommonScrFunc.FUNC_RETURN:
										writer.Write("{0}{1}", indent, funcNames[functioncall.Function]);
										break;
									default:
										writer.Write("{0}{1}({2})", indent, funcNames[functioncall.Function], string.Join(", ", functioncall.Arguments.Select(a => GetVarText(a, writer))));
										break;
								}
							}
							break;
					}
					if (!string.IsNullOrEmpty(line.Comment))
					{
						if (!(line is ScriptLineEmpty))
							writer.Write(' ');
						writer.Write("//");
						writer.Write(line.Comment);
					}
					writer.WriteLine();
					if (tablesize.HasValue)
						writer.WriteLine("\t{0}", string.Join(", ", Enumerable.Repeat("0", tablesize.Value)));
				}
		}
	}
}
