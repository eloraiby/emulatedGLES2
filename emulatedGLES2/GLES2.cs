/*
** Emulated GLES2 for .Net
** Copyright (C) 2015  Wael El Oraiby
** 
** This program is free software: you can redistribute it and/or modify
** it under the terms of the GNU Affero General Public License as
** published by the Free Software Foundation, either version 3 of the
** License, or (at your option) any later version.
** 
** This program is distributed in the hope that it will be useful,
** but WITHOUT ANY WARRANTY; without even the implied warranty of
** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
** GNU Affero General Public License for more details.
** 
** You should have received a copy of the GNU Affero General Public License
** along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Render
{
    using uint32 = UInt32;
    using sint32 = Int32;
    using GLboolean = Char;
    using GLubyte = Char;

    public enum GLenum
    {
        GL_DEPTH_BUFFER_BIT = 0x00000100,
        GL_STENCIL_BUFFER_BIT = 0x00000400,
        GL_COLOR_BUFFER_BIT = 0x00004000,
        GL_FALSE = 0,
        GL_TRUE = 1,
        GL_POINTS = 0x0000,
        GL_LINES = 0x0001,
        GL_LINE_LOOP = 0x0002,
        GL_LINE_STRIP = 0x0003,
        GL_TRIANGLES = 0x0004,
        GL_TRIANGLE_STRIP = 0x0005,
        GL_TRIANGLE_FAN = 0x0006,
        GL_ZERO = 0,
        GL_ONE = 1,
        GL_SRC_COLOR = 0x0300,
        GL_ONE_MINUS_SRC_COLOR = 0x0301,
        GL_SRC_ALPHA = 0x0302,
        GL_ONE_MINUS_SRC_ALPHA = 0x0303,
        GL_DST_ALPHA = 0x0304,
        GL_ONE_MINUS_DST_ALPHA = 0x0305,
        GL_DST_COLOR = 0x0306,
        GL_ONE_MINUS_DST_COLOR = 0x0307,
        GL_SRC_ALPHA_SATURATE = 0x0308,
        GL_FUNC_ADD = 0x8006,
        GL_BLEND_EQUATION = 0x8009,
        GL_BLEND_EQUATION_RGB = 0x8009,
        GL_BLEND_EQUATION_ALPHA = 0x883D,
        GL_FUNC_SUBTRACT = 0x800A,
        GL_FUNC_REVERSE_SUBTRACT = 0x800B,
        GL_BLEND_DST_RGB = 0x80C8,
        GL_BLEND_SRC_RGB = 0x80C9,
        GL_BLEND_DST_ALPHA = 0x80CA,
        GL_BLEND_SRC_ALPHA = 0x80CB,
        GL_CONSTANT_COLOR = 0x8001,
        GL_ONE_MINUS_CONSTANT_COLOR = 0x8002,
        GL_CONSTANT_ALPHA = 0x8003,
        GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004,
        GL_BLEND_COLOR = 0x8005,
        GL_ARRAY_BUFFER = 0x8892,
        GL_ELEMENT_ARRAY_BUFFER = 0x8893,
        GL_ARRAY_BUFFER_BINDING = 0x8894,
        GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895,
        GL_STREAM_DRAW = 0x88E0,
        GL_STATIC_DRAW = 0x88E4,
        GL_DYNAMIC_DRAW = 0x88E8,
        GL_BUFFER_SIZE = 0x8764,
        GL_BUFFER_USAGE = 0x8765,
        GL_CURRENT_VERTEX_ATTRIB = 0x8626,
        GL_FRONT = 0x0404,
        GL_BACK = 0x0405,
        GL_FRONT_AND_BACK = 0x0408,
        GL_TEXTURE_2D = 0x0DE1,
        GL_CULL_FACE = 0x0B44,
        GL_BLEND = 0x0BE2,
        GL_DITHER = 0x0BD0,
        GL_STENCIL_TEST = 0x0B90,
        GL_DEPTH_TEST = 0x0B71,
        GL_SCISSOR_TEST = 0x0C11,
        GL_POLYGON_OFFSET_FILL = 0x8037,
        GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E,
        GL_SAMPLE_COVERAGE = 0x80A0,
        GL_NO_ERROR = 0,
        GL_INVALID_ENUM = 0x0500,
        GL_INVALID_VALUE = 0x0501,
        GL_INVALID_OPERATION = 0x0502,
        GL_OUT_OF_MEMORY = 0x0505,
        GL_CW = 0x0900,
        GL_CCW = 0x0901,
        GL_LINE_WIDTH = 0x0B21,
        GL_ALIASED_POINT_SIZE_RANGE = 0x846D,
        GL_ALIASED_LINE_WIDTH_RANGE = 0x846E,
        GL_CULL_FACE_MODE = 0x0B45,
        GL_FRONT_FACE = 0x0B46,
        GL_DEPTH_RANGE = 0x0B70,
        GL_DEPTH_WRITEMASK = 0x0B72,
        GL_DEPTH_CLEAR_VALUE = 0x0B73,
        GL_DEPTH_FUNC = 0x0B74,
        GL_STENCIL_CLEAR_VALUE = 0x0B91,
        GL_STENCIL_FUNC = 0x0B92,
        GL_STENCIL_FAIL = 0x0B94,
        GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95,
        GL_STENCIL_PASS_DEPTH_PASS = 0x0B96,
        GL_STENCIL_REF = 0x0B97,
        GL_STENCIL_VALUE_MASK = 0x0B93,
        GL_STENCIL_WRITEMASK = 0x0B98,
        GL_STENCIL_BACK_FUNC = 0x8800,
        GL_STENCIL_BACK_FAIL = 0x8801,
        GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802,
        GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803,
        GL_STENCIL_BACK_REF = 0x8CA3,
        GL_STENCIL_BACK_VALUE_MASK = 0x8CA4,
        GL_STENCIL_BACK_WRITEMASK = 0x8CA5,
        GL_VIEWPORT = 0x0BA2,
        GL_SCISSOR_BOX = 0x0C10,
        GL_COLOR_CLEAR_VALUE = 0x0C22,
        GL_COLOR_WRITEMASK = 0x0C23,
        GL_UNPACK_ALIGNMENT = 0x0CF5,
        GL_PACK_ALIGNMENT = 0x0D05,
        GL_MAX_TEXTURE_SIZE = 0x0D33,
        GL_MAX_VIEWPORT_DIMS = 0x0D3A,
        GL_SUBPIXEL_BITS = 0x0D50,
        GL_RED_BITS = 0x0D52,
        GL_GREEN_BITS = 0x0D53,
        GL_BLUE_BITS = 0x0D54,
        GL_ALPHA_BITS = 0x0D55,
        GL_DEPTH_BITS = 0x0D56,
        GL_STENCIL_BITS = 0x0D57,
        GL_POLYGON_OFFSET_UNITS = 0x2A00,
        GL_POLYGON_OFFSET_FACTOR = 0x8038,
        GL_TEXTURE_BINDING_2D = 0x8069,
        GL_SAMPLE_BUFFERS = 0x80A8,
        GL_SAMPLES = 0x80A9,
        GL_SAMPLE_COVERAGE_VALUE = 0x80AA,
        GL_SAMPLE_COVERAGE_INVERT = 0x80AB,
        GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2,
        GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3,
        GL_DONT_CARE = 0x1100,
        GL_FASTEST = 0x1101,
        GL_NICEST = 0x1102,
        GL_GENERATE_MIPMAP_HINT = 0x8192,
        GL_BYTE = 0x1400,
        GL_UNSIGNED_BYTE = 0x1401,
        GL_SHORT = 0x1402,
        GL_UNSIGNED_SHORT = 0x1403,
        GL_INT = 0x1404,
        GL_UNSIGNED_INT = 0x1405,
        GL_FLOAT = 0x1406,
        GL_FIXED = 0x140C,
        GL_DEPTH_COMPONENT = 0x1902,
        GL_ALPHA = 0x1906,
        GL_RGB = 0x1907,
        GL_RGBA = 0x1908,
        GL_LUMINANCE = 0x1909,
        GL_LUMINANCE_ALPHA = 0x190A,
        GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033,
        GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034,
        GL_UNSIGNED_SHORT_5_6_5 = 0x8363,
        GL_FRAGMENT_SHADER = 0x8B30,
        GL_VERTEX_SHADER = 0x8B31,
        GL_MAX_VERTEX_ATTRIBS = 0x8869,
        GL_MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB,
        GL_MAX_VARYING_VECTORS = 0x8DFC,
        GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D,
        GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C,
        GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872,
        GL_MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD,
        GL_SHADER_TYPE = 0x8B4F,
        GL_DELETE_STATUS = 0x8B80,
        GL_LINK_STATUS = 0x8B82,
        GL_VALIDATE_STATUS = 0x8B83,
        GL_ATTACHED_SHADERS = 0x8B85,
        GL_ACTIVE_UNIFORMS = 0x8B86,
        GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87,
        GL_ACTIVE_ATTRIBUTES = 0x8B89,
        GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A,
        GL_SHADING_LANGUAGE_VERSION = 0x8B8C,
        GL_CURRENT_PROGRAM = 0x8B8D,
        GL_NEVER = 0x0200,
        GL_LESS = 0x0201,
        GL_EQUAL = 0x0202,
        GL_LEQUAL = 0x0203,
        GL_GREATER = 0x0204,
        GL_NOTEQUAL = 0x0205,
        GL_GEQUAL = 0x0206,
        GL_ALWAYS = 0x0207,
        GL_KEEP = 0x1E00,
        GL_REPLACE = 0x1E01,
        GL_INCR = 0x1E02,
        GL_DECR = 0x1E03,
        GL_INVERT = 0x150A,
        GL_INCR_WRAP = 0x8507,
        GL_DECR_WRAP = 0x8508,
        GL_VENDOR = 0x1F00,
        GL_RENDERER = 0x1F01,
        GL_VERSION = 0x1F02,
        GL_EXTENSIONS = 0x1F03,
        GL_NEAREST = 0x2600,
        GL_LINEAR = 0x2601,
        GL_NEAREST_MIPMAP_NEAREST = 0x2700,
        GL_LINEAR_MIPMAP_NEAREST = 0x2701,
        GL_NEAREST_MIPMAP_LINEAR = 0x2702,
        GL_LINEAR_MIPMAP_LINEAR = 0x2703,
        GL_TEXTURE_MAG_FILTER = 0x2800,
        GL_TEXTURE_MIN_FILTER = 0x2801,
        GL_TEXTURE_WRAP_S = 0x2802,
        GL_TEXTURE_WRAP_T = 0x2803,
        GL_TEXTURE = 0x1702,
        GL_TEXTURE_CUBE_MAP = 0x8513,
        GL_TEXTURE_BINDING_CUBE_MAP = 0x8514,
        GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515,
        GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516,
        GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517,
        GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518,
        GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519,
        GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A,
        GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C,
        GL_TEXTURE0 = 0x84C0,
        GL_TEXTURE1 = 0x84C1,
        GL_TEXTURE2 = 0x84C2,
        GL_TEXTURE3 = 0x84C3,
        GL_TEXTURE4 = 0x84C4,
        GL_TEXTURE5 = 0x84C5,
        GL_TEXTURE6 = 0x84C6,
        GL_TEXTURE7 = 0x84C7,
        GL_TEXTURE8 = 0x84C8,
        GL_TEXTURE9 = 0x84C9,
        GL_TEXTURE10 = 0x84CA,
        GL_TEXTURE11 = 0x84CB,
        GL_TEXTURE12 = 0x84CC,
        GL_TEXTURE13 = 0x84CD,
        GL_TEXTURE14 = 0x84CE,
        GL_TEXTURE15 = 0x84CF,
        GL_TEXTURE16 = 0x84D0,
        GL_TEXTURE17 = 0x84D1,
        GL_TEXTURE18 = 0x84D2,
        GL_TEXTURE19 = 0x84D3,
        GL_TEXTURE20 = 0x84D4,
        GL_TEXTURE21 = 0x84D5,
        GL_TEXTURE22 = 0x84D6,
        GL_TEXTURE23 = 0x84D7,
        GL_TEXTURE24 = 0x84D8,
        GL_TEXTURE25 = 0x84D9,
        GL_TEXTURE26 = 0x84DA,
        GL_TEXTURE27 = 0x84DB,
        GL_TEXTURE28 = 0x84DC,
        GL_TEXTURE29 = 0x84DD,
        GL_TEXTURE30 = 0x84DE,
        GL_TEXTURE31 = 0x84DF,
        GL_ACTIVE_TEXTURE = 0x84E0,
        GL_REPEAT = 0x2901,
        GL_CLAMP_TO_EDGE = 0x812F,
        GL_MIRRORED_REPEAT = 0x8370,
        GL_FLOAT_VEC2 = 0x8B50,
        GL_FLOAT_VEC3 = 0x8B51,
        GL_FLOAT_VEC4 = 0x8B52,
        GL_INT_VEC2 = 0x8B53,
        GL_INT_VEC3 = 0x8B54,
        GL_INT_VEC4 = 0x8B55,
        GL_BOOL = 0x8B56,
        GL_BOOL_VEC2 = 0x8B57,
        GL_BOOL_VEC3 = 0x8B58,
        GL_BOOL_VEC4 = 0x8B59,
        GL_FLOAT_MAT2 = 0x8B5A,
        GL_FLOAT_MAT3 = 0x8B5B,
        GL_FLOAT_MAT4 = 0x8B5C,
        GL_SAMPLER_2D = 0x8B5E,
        GL_SAMPLER_CUBE = 0x8B60,
        GL_VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622,
        GL_VERTEX_ATTRIB_ARRAY_SIZE = 0x8623,
        GL_VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624,
        GL_VERTEX_ATTRIB_ARRAY_TYPE = 0x8625,
        GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A,
        GL_VERTEX_ATTRIB_ARRAY_POINTER = 0x8645,
        GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F,
        GL_IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A,
        GL_IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B,
        GL_COMPILE_STATUS = 0x8B81,
        GL_INFO_LOG_LENGTH = 0x8B84,
        GL_SHADER_SOURCE_LENGTH = 0x8B88,
        GL_SHADER_COMPILER = 0x8DFA,
        GL_SHADER_BINARY_FORMATS = 0x8DF8,
        GL_NUM_SHADER_BINARY_FORMATS = 0x8DF9,
        GL_LOW_FLOAT = 0x8DF0,
        GL_MEDIUM_FLOAT = 0x8DF1,
        GL_HIGH_FLOAT = 0x8DF2,
        GL_LOW_INT = 0x8DF3,
        GL_MEDIUM_INT = 0x8DF4,
        GL_HIGH_INT = 0x8DF5,
        GL_FRAMEBUFFER = 0x8D40,
        GL_RENDERBUFFER = 0x8D41,
        GL_RGBA4 = 0x8056,
        GL_RGB5_A1 = 0x8057,
        GL_RGB565 = 0x8D62,
        GL_DEPTH_COMPONENT16 = 0x81A5,
        GL_STENCIL_INDEX8 = 0x8D48,
        GL_RENDERBUFFER_WIDTH = 0x8D42,
        GL_RENDERBUFFER_HEIGHT = 0x8D43,
        GL_RENDERBUFFER_INTERNAL_FORMAT = 0x8D44,
        GL_RENDERBUFFER_RED_SIZE = 0x8D50,
        GL_RENDERBUFFER_GREEN_SIZE = 0x8D51,
        GL_RENDERBUFFER_BLUE_SIZE = 0x8D52,
        GL_RENDERBUFFER_ALPHA_SIZE = 0x8D53,
        GL_RENDERBUFFER_DEPTH_SIZE = 0x8D54,
        GL_RENDERBUFFER_STENCIL_SIZE = 0x8D55,
        GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0,
        GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1,
        GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2,
        GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3,
        GL_COLOR_ATTACHMENT0 = 0x8CE0,
        GL_DEPTH_ATTACHMENT = 0x8D00,
        GL_STENCIL_ATTACHMENT = 0x8D20,
        GL_NONE = 0,
        GL_FRAMEBUFFER_COMPLETE = 0x8CD5,
        GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6,
        GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7,
        GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 0x8CD9,
        GL_FRAMEBUFFER_UNSUPPORTED = 0x8CDD,
        GL_FRAMEBUFFER_BINDING = 0x8CA6,
        GL_RENDERBUFFER_BINDING = 0x8CA7,
        GL_MAX_RENDERBUFFER_SIZE = 0x84E8,
        GL_INVALID_FRAMEBUFFER_OPERATION = 0x0506,
    }

    public struct GLAttribute {
        public uint32 size;
        public GLenum glType;
        public string name;

        public GLAttribute(uint32 size, GLenum glType, string name) {
            this.size = size;
            this.glType = glType;
            this.name = name;
        }
    }

    public struct GLUniform {
        public uint32 size;
        public GLenum glType;
        public string name;

        public GLUniform(uint32 size, GLenum glType, string name) {
            this.size = size;
            this.glType = glType;
            this.name = name;
        }
    }

    public struct GLPrecision {
        public sint32 range;
        public sint32 precision;

        public GLPrecision(sint32 range, sint32 precision) {
            this.range = range;
            this.precision = precision;
        }
    }

    public unsafe static class GLES2
    {
        public static void      glActiveTexture        (GLenum texture) {
            emu_glActiveTexture (texture);
        }

        public static void      glAttachShader         (uint32 program, uint32 shader) {
            emu_glAttachShader (program, shader);
        }

        public static void      glBindAttribLocation   (uint32 program, uint32 index, string name) {
            fixed(char* arr = name.ToCharArray()) {
                emu_glBindAttribLocation (program, index, arr);
            }
        }

        public static void      glBindBuffer           (GLenum target, uint32 buffer) {
            emu_glBindBuffer (target, buffer);
        }

        public static void      glBindFramebuffer      (GLenum target, uint32 framebuffer) {
            emu_glBindFramebuffer (target, framebuffer);
        }

        public static void      glBindRenderbuffer     (GLenum target, uint32 renderbuffer) {
            emu_glBindRenderbuffer (target, renderbuffer);
        }

        public static void      glBindTexture          (GLenum target, uint32 texture) {
            emu_glBindTexture (target, texture);
        }

        public static void      glBlendColor           (float red, float green, float blue, float alpha) {
            emu_glBlendColor (red, green, blue, alpha);
        }

        public static void      glBlendEquation        (GLenum mode) {
            emu_glBlendEquation (mode);
        }

        public static void      glBlendEquationSeparate(GLenum modeRGB, GLenum modeAlpha) {
            emu_glBlendEquationSeparate (modeRGB, modeAlpha);
        }

        public static void      glBlendFunc            (GLenum sfactor, GLenum dfactor) {
            emu_glBlendFunc (sfactor, dfactor);
        }

        public static void      glBlendFuncSeparate    (GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha) {
            emu_glBlendFuncSeparate (sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);
        }

        public static void      glBufferData        (GLenum target, uint32 size, IntPtr data, GLenum usage) {
            emu_glBufferData (target, size, (void*)data, usage);
        }

        public static void      glBufferSubData        (GLenum target, uint32 offset, uint32 size, IntPtr data) {
            emu_glBufferSubData (target, offset, size, (void*)data);
        }

        public static GLenum    glCheckFramebufferStatus   (GLenum target) {
            return emu_glCheckFramebufferStatus (target);
        }

        public static void      glClear                (uint32 mask) {
            emu_glClear (mask);
        }

        public static void      glClearColor           (float red, float green, float blue, float alpha) {
            emu_glClearColor (red, green, blue, alpha);
        }

        public static void      glClearDepthf          (float d) {
            emu_glClearDepthf (d);
        }

        public static void      glClearStencil         (sint32 s) {
            emu_glClearStencil (s);
        }

        public static void      glColorMask            (bool red, bool green, bool blue, bool alpha) {
            var r = (GLboolean)(red ? GLenum.GL_TRUE : GLenum.GL_FALSE);
            var g = (GLboolean)(green ? GLenum.GL_TRUE : GLenum.GL_FALSE);
            var b = (GLboolean)(blue ? GLenum.GL_TRUE : GLenum.GL_FALSE);
            var a = (GLboolean)(alpha ? GLenum.GL_TRUE : GLenum.GL_FALSE);
            emu_glColorMask (r, g, b, a);
        }

        public static void      glCompileShader        (uint32 shader) {
            emu_glCompileShader (shader);
        }

        public static void      glCompressedTexImage2D (GLenum target, sint32 level, GLenum internalformat, uint32 width, uint32 height, sint32 border, uint32 imageSize, IntPtr data) {
            emu_glCompressedTexImage2D (target, level, internalformat, width, height, border, imageSize, (void*)data);
        }

        public static void      glCompressedTexSubImage2D  (GLenum target, sint32 level, sint32 xoffset, sint32 yoffset, uint32 width, uint32 height, GLenum format, uint32 imageSize, IntPtr data) {
            emu_glCompressedTexSubImage2D (target, level, xoffset, yoffset, width, height, format, imageSize, (void*)data);
        }

        public static void      glCopyTexImage2D       (GLenum target, sint32 level, GLenum internalformat, sint32 x, sint32 y, uint32 width, uint32 height, sint32 border) {
            emu_glCopyTexImage2D (target, level, internalformat, x, y, width, height, border);
        }

        public static void      glCopyTexSubImage2D    (GLenum target, sint32 level, sint32 xoffset, sint32 yoffset, sint32 x, sint32 y, uint32 width, uint32 height) {
            emu_glCopyTexSubImage2D (target, level, xoffset, yoffset, x, y, width, height);
        }

        public static uint32    glCreateProgram        () {
            return emu_glCreateProgram ();
        }

        public static uint32    glCreateShader         (GLenum type) {
            return emu_glCreateShader (type);
        }

        public static void      glCullFace             (GLenum mode) {
            emu_glCullFace (mode);
        }

        public static void      glDeleteBuffers        (uint32[] buffers) {
            var n = (uint32)buffers.Length;
            fixed(uint32* b = buffers) {
                emu_glDeleteBuffers (n, b);
            }
        }

        public static void      glDeleteFramebuffers   (uint32[] framebuffers) {
            var n = (uint32)framebuffers.Length;
            fixed(uint32* b = framebuffers) {
                emu_glDeleteFramebuffers (n, b);
            }
        }

        public static void      glDeleteProgram        (uint32 program) {
            emu_glDeleteProgram (program);
        }

        public static void      glDeleteRenderbuffers  (uint32[] renderbuffers) {
            var n = (uint32)renderbuffers.Length;
            fixed(uint32* rb = renderbuffers) {
                emu_glDeleteRenderbuffers (n, rb);
            }
        }

        public static void      glDeleteShader         (uint32 shader) {
            emu_glDeleteShader (shader);
        }

        public static void      glDeleteTextures       (uint32[] textures) {
            var n = (uint32)textures.Length;
            fixed(uint32* ts = textures) {
                emu_glDeleteTextures (n, ts);
            }
        }

        public static void      glDepthFunc            (GLenum func) {
            emu_glDepthFunc (func);
        }

        public static void      glDepthMask            (bool flag) {
            var b = (GLboolean)(flag ? GLenum.GL_TRUE : GLenum.GL_FALSE);
            emu_glDepthMask (b);
        }

        public static void      glDepthRangef          (float n, float f) {
            emu_glDepthRangef (n, f);
        }

        public static void      glDetachShader         (uint32 program, uint32 shader) {
            emu_glDetachShader (program, shader);
        }

        public static void      glDisable              (GLenum cap) {
            emu_glDisable (cap);
        }

        public static void      glDisableVertexAttribArray (uint32 index) {
            emu_glDisableVertexAttribArray (index);
        }

        public static void      glDrawArrays           (GLenum mode, sint32 first, uint32 count) {
            emu_glDrawArrays (mode, first, count);
        }

        public static void      glDrawElements         (GLenum mode, uint32 count, GLenum type, IntPtr indices) {
            emu_glDrawElements (mode, count, type, (void*)indices);
        }

        public static void      glEnable               (GLenum cap) {
            emu_glEnable (cap);
        }

        public static void      glEnableVertexAttribArray  (uint32 index) {
            emu_glEnableVertexAttribArray (index);
        }

        public static void      glFinish               () {
            emu_glFinish ();
        }

        public static void      glFlush                () {
            emu_glFlush ();
        }

        public static void      glFramebufferRenderbuffer  (GLenum target, GLenum attachment, GLenum renderbuffertarget, uint32 renderbuffer) {
            emu_glFramebufferRenderbuffer (target, attachment, renderbuffertarget, renderbuffer);
        }

        public static void      glFramebufferTexture2D (GLenum target, GLenum attachment, GLenum textarget, uint32 texture, sint32 level) {
            emu_glFramebufferTexture2D (target, attachment, textarget, texture, level);
        }

        public static void      glFrontFace            (GLenum mode) {
            emu_glFrontFace (mode);
        }

        public static uint32[]  glGenBuffers           (uint32 n) {
            var bs = new uint32 [n];
            fixed(uint32* b = bs) {
                emu_glGenBuffers (n, b);
            }
            return bs;
        }

        public static void      glGenerateMipmap       (GLenum target) {
            emu_glGenerateMipmap (target);
        }

        public static uint32[]  glGenFramebuffers      (uint32 n) {
            var bs = new uint32 [n];
            fixed(uint32* b = bs) {
                emu_glGenFramebuffers (n, b);
            }
            return bs;           
        }

        public static uint32[]  glGenRenderbuffers     (uint32 n) {
            var bs = new uint32 [n];
            fixed(uint32* b = bs) {
                emu_glGenRenderbuffers (n, b);
            }
            return bs;           
        }

        public static uint32[]  glGenTextures          (uint32 n) {
            var bs = new uint32 [n];
            fixed(uint32* b = bs) {
                emu_glGenTextures (n, b);
            }
            return bs;           
        }

        public static GLAttribute   glGetActiveAttrib  (uint32 program, uint32 index) {
            var name = new char[MaxStrLength];
            int size;
            int length;
            GLenum glType;

            fixed(char* n = name) {
                emu_glGetActiveAttrib (program, index, MaxStrLength - 1, &length, &size, &glType, n);
            }

            var name_ = new String (name).Substring (0, length);

            return new GLAttribute ((uint32)size, glType, name_);
        }

        public static GLUniform   glGetActiveUniform   (uint32 program, uint32 index) {
            var name = new char[MaxStrLength];
            int size;
            int length;
            GLenum glType;

            fixed(char* n = name) {
                emu_glGetActiveUniform (program, index, MaxStrLength - 1, &length, &size, &glType, n);
            }

            var name_ = new String (name).Substring (0, length);

            return new GLUniform ((uint32)size, glType, name_);
        }

        public static uint32[]    glGetAttachedShaders  (uint32 program) {
            var shaders = new uint32[MaxAttachedShaders];
            int count;
            fixed(uint32* s = shaders) {
                emu_glGetAttachedShaders (program, MaxAttachedShaders, &count, s);
            }

            return shaders.Take (count).ToArray();
        }

        public static sint32    glGetAttribLocation    (uint32 program, string name) {
            fixed(char *ns = name.ToCharArray()) {
                return emu_glGetAttribLocation (program, ns);
            }
        }

        public static bool      glGetBoolean           (GLenum pname) {
            GLboolean b;
            emu_glGetBooleanv (pname, &b);
            return (b != (GLboolean)GLenum.GL_FALSE);
        }

        public static sint32    glGetBufferParameteri  (GLenum target, GLenum pname) {
            sint32 parms;
            emu_glGetBufferParameteriv (target, pname, &parms);
            return parms;
        }

        public static GLenum    glGetError             () {
            return emu_glGetError ();
        }

        public static float     glGetFloat             (GLenum pname) {
            float v;
            emu_glGetFloatv (pname, &v);
            return v;
        }

        public static sint32    glGetFramebufferAttachmentParameteri (GLenum target, GLenum attachment, GLenum pname) {
            sint32 i;
            emu_glGetFramebufferAttachmentParameteriv (target, attachment, pname, &i);
            return i;
        }
            
        public static sint32    glGetInteger          (GLenum pname) {
            sint32 i;
            emu_glGetIntegerv (pname, &i);
            return i;
        }

        public static sint32    glGetProgrami         (uint32 program, GLenum pname) {
            sint32 p;
            emu_glGetProgramiv (program, pname, &p);
            return p;
        }

        public static string    glGetProgramInfoLog    (uint32 program) {
            var log_ = new char[MaxLogSize];
            uint32 size;
            fixed(char* l = log_) {
                emu_glGetProgramInfoLog (program, MaxLogSize, &size, l);
            }
            return new String (log_.Take ((int)size).ToArray());
        }

        public static sint32    glGetRenderbufferParameteri   (GLenum target, GLenum pname) {
            sint32 i;
            emu_glGetRenderbufferParameteriv(target, pname, &i);
            return i;
        }

        public static sint32    glGetShaderi          (uint32 shader, GLenum pname) {
            sint32 i;
            emu_glGetShaderiv (shader, pname, &i);
            return i;
        }

        public static string    glGetShaderInfoLog    (uint32 shader) {
            var log_ = new char[MaxLogSize];
            uint32 size;
            fixed(char* l = log_) {
                emu_glGetShaderInfoLog (shader, MaxLogSize, &size, l);
            }
            return new String (log_.Take ((int)size).ToArray());            
        }

        public static GLPrecision glGetShaderPrecisionFormat (GLenum shadertype, GLenum precisiontype) {
            sint32 r;
            sint32 p;
            emu_glGetShaderPrecisionFormat (shadertype, precisiontype, &r, &p);
            return new GLPrecision (r, p);
        }

        public static string      glGetShaderSource      (uint32 shader) {
            var source_ = new char[MaxShaderSize];
            uint32 size;
            fixed(char* s = source_) {
                emu_glGetShaderSource (shader, MaxShaderSize, &size, s);
            }
            return new String (source_.Take ((int)size).ToArray());             
        }

// this requires marshaling
//        public static string      glGetString       (GLenum name) {
//            var err_ = new GLubyte[MaxLogSize];
//            uint32 size;
//            fixed(char* s = source_) {
//                emu_glGetString (shader, MaxShaderSize, &size, s);
//            }
//            return new String (source_.Take ((int)size).ToArray());             
//        }

        public static float     glGetTexParameterf     (GLenum target, GLenum pname) {
            float f;
            emu_glGetTexParameterfv(target, pname, &f);
            return f;
        }

        public static sint32    glGetTexParameteri     (GLenum target, GLenum pname) {
            sint32 i;
            emu_glGetTexParameteriv(target, pname, &i);
            return i;
        }

        public static float[]   glGetUniformf          (uint32 program, sint32 location) {
            var fla = new float[4];
            fixed(float *f = fla) {
                emu_glGetUniformfv (program, location, f);
            }
            return fla;
        }
            
        public static sint32[]  glGetUniformi          (uint32 program, sint32 location) {
            var ia = new sint32[4];
            fixed(sint32 *i = ia) {
                emu_glGetUniformiv (program, location, i);
            }
            return ia;
        }

        public static sint32    glGetUniformLocation       (uint32 program, string name) {
            fixed(char* c = name) {
                return emu_glGetUniformLocation (program, c);
            }
        }

        public static float     glGetVertexAttribf         (uint32 index, GLenum pname) {
            float v;
            emu_glGetVertexAttribfv (index, pname, &v);
            return v;
        }

        public static sint32    glGetVertexAttribi         (uint32 index, GLenum pname) {
            sint32 i;
            emu_glGetVertexAttribiv (index, pname, &i);
            return i;
        }

        public static IntPtr    glGetVertexAttribPointerv  (uint32 index, GLenum pname) {
            IntPtr ip;
            emu_glGetVertexAttribPointerv (index, pname, (void**)&ip);
            return ip;
        }

        public static void      glHint                 (GLenum target, GLenum mode) {
            emu_glHint (target, mode);
        }

        public static bool      glIsBuffer             (uint32 buffer) {
            return GLenum.GL_FALSE != (GLenum)emu_glIsBuffer(buffer);
        }

        public static bool      glIsEnabled            (GLenum cap) {
            return GLenum.GL_FALSE != (GLenum)emu_glIsEnabled (cap);
        }

        public static bool      glIsFramebuffer        (uint32 framebuffer) {
            return GLenum.GL_FALSE != (GLenum) emu_glIsFramebuffer (framebuffer);
        }

        public static bool      glIsProgram            (uint32 program) {
            return GLenum.GL_FALSE != (GLenum)emu_glIsProgram (program);
        }

        public static bool      glIsRenderbuffer       (uint32 renderbuffer) {
            return GLenum.GL_FALSE != (GLenum)emu_glIsRenderbuffer (renderbuffer);
        }

        public static bool      glIsShader             (uint32 shader) {
            return GLenum.GL_FALSE != (GLenum)emu_glIsShader (shader);
        }

        public static bool      glIsTexture            (uint32 texture) {
            return GLenum.GL_FALSE != (GLenum)emu_glIsTexture (texture);
        }

        public static void      glLineWidth            (float width) {
            emu_glLineWidth (width);
        }

        public static void      glLinkProgram          (uint32 program) {
            emu_glLinkProgram (program);
        }

        public static void      glPixelStorei          (GLenum pname, sint32 param) {
            emu_glPixelStorei (pname, param);
        }

        public static void      glPolygonOffset        (float factor, float units) {
            emu_glPolygonOffset (factor, units);
        }

        public static void      glReadPixels           (sint32 x, sint32 y, uint32 width, uint32 height, GLenum format, GLenum type, IntPtr pixels) {
            emu_glReadPixels (x, y, width, height, format, type, (void*)pixels);
        }

        public static void      glReleaseShaderCompiler() {
            emu_glReleaseShaderCompiler ();
        }

        public static void      glRenderbufferStorage  (GLenum target, GLenum internalformat, uint32 width, uint32 height) {
            emu_glRenderbufferStorage (target, internalformat, width, height);
        }

        public static void      glSampleCoverage       (float value, bool invert) {
            emu_glSampleCoverage (value, (GLboolean)(invert ? GLenum.GL_TRUE : GLenum.GL_FALSE));
        }

        public static void      glScissor              (sint32 x, sint32 y, uint32 width, uint32 height) {
            emu_glScissor (x, y, width, height);
        }

        public static void      glShaderBinary         (uint32[] shaders, GLenum binaryformat, IntPtr binary, uint32 length) {
            var count = (uint32)shaders.Length;
            fixed(uint32* s = shaders) {
                emu_glShaderBinary (count, s, binaryformat, (void*)binary, length);
            }
        }

        public static void      glShaderSource         (uint32 shader, string[] shaders) {
            var lengths = new sint32[shaders.Length];
            var shaders_ = new char*[shaders.Length];

            for (var i = 0; i < shaders.Length; ++i) {
                lengths [i] = shaders [i].Length;
                fixed(char* s = shaders[i].ToCharArray()) {
                    shaders_ [i] = s;
                }
            }

            fixed(char** shaders__ = shaders_) {
                fixed(sint32* lengths_ = lengths) {
                    emu_glShaderSource (shader, (uint32)shaders.Length, shaders__, lengths_);
                }
            }
        }

        public static void      glStencilFunc          (GLenum func, sint32 ref_, uint32 mask) {
            emu_glStencilFunc (func, ref_, mask);
        }

        public static void      glStencilFuncSeparate  (GLenum face, GLenum func, sint32 ref_, uint32 mask) {
            emu_glStencilFuncSeparate (face, func, ref_, mask);
        }

        public static void      glStencilMask          (uint32 mask) {
            emu_glStencilMask (mask);
        }

        public static void      glStencilMaskSeparate  (GLenum face, uint32 mask) {
            emu_glStencilMaskSeparate (face, mask);
        }

        public static void      glStencilOp            (GLenum fail, GLenum zfail, GLenum zpass) {
            emu_glStencilOp (fail, zfail, zpass);
        }

        public static void      glStencilOpSeparate    (GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass) {
            emu_glStencilOpSeparate (face, sfail, dpfail, dppass);
        }

        public static void      glTexImage2D           (GLenum target, sint32 level, sint32 internalformat, uint32 width, uint32 height, sint32 border, GLenum format, GLenum type, IntPtr pixels) {
            emu_glTexImage2D (target, level, internalformat, width, height, border, format, type, (void*)pixels);
        }

        public static void      glTexParameterf        (GLenum target, GLenum pname, float param) {
            emu_glTexParameterf (target, pname, param);
        }

        public static void      glTexParameterf        (GLenum target, GLenum pname, float[] parms) {
            fixed(float* p = parms) {
                emu_glGetTexParameterfv (target, pname, p);
            }
        }

        public static void      glTexParameteri        (GLenum target, GLenum pname, sint32 param) {
            emu_glTexParameteri (target, pname, param);
        }

        public static void      glTexParameteri        (GLenum target, GLenum pname, sint32[] parms) {
            fixed(sint32* p = parms) {
                emu_glTexParameteriv (target, pname, p);
            }
        }


        public static void      glTexSubImage2D        (GLenum target, sint32 level, sint32 xoffset, sint32 yoffset, uint32 width, uint32 height, GLenum format, GLenum type, IntPtr pixels) {
            emu_glTexSubImage2D (target, level, xoffset, yoffset, width, height, format, type, (void*)pixels);
        }

        public static void      glUniform1f            (sint32 location, float v0) {
            emu_glUniform1f (location, v0);
        }

        public static void      glUniform1f            (sint32 location, float[] values) {
            var count = (uint32)values.Length;
            fixed(float* vals = values) {
                emu_glUniform1fv (location, count, vals);
            }
        }

        public static void      glUniform1i            (sint32 location, sint32 v0) {
            emu_glUniform1i (location, v0);
        }

        public static void      glUniform1i            (sint32 location, sint32[] values) {
            var count = (uint32)values.Length;
            fixed(sint32* vals = values) {
                emu_glUniform1iv (location, count, vals);
            }
        }

        public static void      glUniform2f            (sint32 location, float v0, float v1) {
            emu_glUniform2f (location, v0, v1);
        }

        public static void      glUniform2f            (sint32 location, float[] values) {
            var count = (uint32)values.Length;
            fixed(float* vals = values) {
                emu_glUniform2fv (location, count, vals);
            }
        }

        public static void      glUniform2i            (sint32 location, sint32 v0, sint32 v1) {
            emu_glUniform2i (location, v0, v1);
        }

        public static void      glUniform2i            (sint32 location, sint32[] values) {
            var count = (uint32)values.Length;
            fixed(sint32* vals = values) {
                emu_glUniform2iv (location, count, vals);
            }
        }

        public static void      glUniform3f            (sint32 location, float v0, float v1, float v2) {
            emu_glUniform3f (location, v0, v1, v2);
        }

        public static void      glUniform3f            (sint32 location, float[] values) {
            var count = (uint32)values.Length;
            fixed(float* vals = values) {
                emu_glUniform3fv (location, count, vals);
            }
        }

        public static void      glUniform3i            (sint32 location, sint32 v0, sint32 v1, sint32 v2) {
            emu_glUniform3i (location, v0, v1, v2);
        }

        public static void      glUniform3i            (sint32 location, sint32[] values) {
            var count = (uint32)values.Length;
            fixed(sint32* vals = values) {
                emu_glUniform3iv (location, count, vals);
            }
        }

        public static void      glUniform4f            (sint32 location, float v0, float v1, float v2, float v4) {
            emu_glUniform4f (location, v0, v1, v2, v4);
        }

        public static void      glUniform4f            (sint32 location, float[] values) {
            var count = (uint32)values.Length;
            fixed(float* vals = values) {
                emu_glUniform4fv (location, count, vals);
            }
        }

        public static void      glUniform4i            (sint32 location, sint32 v0, sint32 v1, sint32 v2, sint32 v3) {
            emu_glUniform4i (location, v0, v1, v2, v3);
        }

        public static void      glUniform4i            (sint32 location, sint32[] values) {
            var count = (uint32)values.Length;
            fixed(sint32* vals = values) {
                emu_glUniform4iv (location, count, vals);
            }
        }

        public static void      glUniformMatrix2fv     (sint32 location, uint32 count, GLboolean transpose, const float *value);                                                                           
//        public static void      glUniformMatrix3fv     (sint32 location, uint32 count, GLboolean transpose, const float *value);                                                                           
//        public static void      glUniformMatrix4fv     (sint32 location, uint32 count, GLboolean transpose, const float *value);                                                                           
//        public static void      glUseProgram           (uint32 program);                                                                                                                                   
//        public static void      glValidateProgram      (uint32 program);                                                                                                                                   
//        public static void      glVertexAttrib1f       (uint32 index, float x);                                                                                                                            
//        public static void      glVertexAttrib1fv      (uint32 index, const float *v);                                                                                                                     
//        public static void      glVertexAttrib2f       (uint32 index, float x, float y);                                                                                                                   
//        public static void      glVertexAttrib2fv      (uint32 index, const float *v);                                                                                                                     
//        public static void      glVertexAttrib3f       (uint32 index, float x, float y, float z);                                                                                                          
//        public static void      glVertexAttrib3fv      (uint32 index, const float *v);                                                                                                                     
//        public static void      glVertexAttrib4f       (uint32 index, float x, float y, float z, float w);                                                                                                 
//        public static void      glVertexAttrib4fv      (uint32 index, const float *v);                                                                                                                     
//        public static void      glVertexAttribPointer  (uint32 index, sint32 size, GL_ENUM type, GLboolean normalized, uint32 stride, const void *pointer);                                                
//        public static void      glViewport             (sint32 x, sint32 y, uint32 width, uint32 height);                                                                                                  
//
        const string DllName = @"native.dll";
        const int MaxStrLength = 256;
        const int MaxAttachedShaders = 64;
        const int MaxLogSize = 65536;
        const int MaxShaderSize = 65536;

        //[DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        //[return: MarshalAs(UnmanagedType.Bool)]

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glActiveTexture        (GLenum texture);                                                                                                                                  

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glAttachShader         (uint32 program, uint32 shader);                                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBindAttribLocation       (uint32 program, uint32 index, char *name);                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBindBuffer           (GLenum target, uint32 buffer);

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBindFramebuffer      (GLenum target, uint32 framebuffer);                                                                                                               

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBindRenderbuffer     (GLenum target, uint32 renderbuffer);                                                                                                              

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBindTexture          (GLenum target, uint32 texture);                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBlendColor           (float red, float green, float blue, float alpha);                                                                                                  

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBlendEquation        (GLenum mode);                                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBlendEquationSeparate    (GLenum modeRGB, GLenum modeAlpha);                                                                                                               

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBlendFunc            (GLenum sfactor, GLenum dfactor);                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBlendFuncSeparate    (GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);                                                               

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBufferData           (GLenum target, uint32 size, void *data, GLenum usage);                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glBufferSubData        (GLenum target, uint32 offset, uint32 size, void *data);                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLenum    emu_glCheckFramebufferStatus   (GLenum target);

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glClear                 (uint32 mask);

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glClearColor           (float red, float green, float blue, float alpha);                                                                                                  

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glClearDepthf          (float d);                                                                                                                                          

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glClearStencil         (sint32 s);                                                                                                                                         

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glColorMask            (GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);                                                                                  

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glCompileShader        (uint32 shader);                                                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glCompressedTexImage2D (GLenum target, sint32 level, GLenum internalformat, uint32 width, uint32 height, sint32 border, uint32 imageSize, void *data);             

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glCompressedTexSubImage2D  (GLenum target, sint32 level, sint32 xoffset, sint32 yoffset, uint32 width, uint32 height, GLenum format, uint32 imageSize, void *data);    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glCopyTexImage2D       (GLenum target, sint32 level, GLenum internalformat, sint32 x, sint32 y, uint32 width, uint32 height, sint32 border);                             

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glCopyTexSubImage2D    (GLenum target, sint32 level, sint32 xoffset, sint32 yoffset, sint32 x, sint32 y, uint32 width, uint32 height);                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern uint32    emu_glCreateProgram        ();                                                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern uint32    emu_glCreateShader         (GLenum type);                                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glCullFace             (GLenum mode);

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDeleteBuffers        (uint32 n, uint32 *buffers);

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDeleteFramebuffers   (uint32 n, uint32 *framebuffers);                                                                                                             

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDeleteProgram        (uint32 program);                                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDeleteRenderbuffers  (uint32 n, uint32 *renderbuffers);                                                                                                            

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDeleteShader         (uint32 shader);                                                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDeleteTextures       (uint32 n, uint32 *textures);                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDepthFunc            (GLenum func);

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDepthMask            (GLboolean flag);

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDepthRangef          (float n, float f);                                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDetachShader         (uint32 program, uint32 shader);                                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDisable              (GLenum cap);                                                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDisableVertexAttribArray (uint32 index);                                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDrawArrays           (GLenum mode, sint32 first, uint32 count);                                                                                                         

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glDrawElements         (GLenum mode, uint32 count, GLenum type, void *indices);                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glEnable               (GLenum cap);                                                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glEnableVertexAttribArray  (uint32 index);                                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glFinish               ();                                                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glFlush                ();                                                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glFramebufferRenderbuffer  (GLenum target, GLenum attachment, GLenum renderbuffertarget, uint32 renderbuffer);                                                              

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glFramebufferTexture2D     (GLenum target, GLenum attachment, GLenum textarget, uint32 texture, sint32 level);                                                              

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glFrontFace            (GLenum mode);                                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGenBuffers           (uint32 n, uint32 *buffers);                                                                                                                        

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGenerateMipmap       (GLenum target);                                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGenFramebuffers      (uint32 n, uint32 *framebuffers);                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGenRenderbuffers     (uint32 n, uint32 *renderbuffers);                                                                                                                  

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGenTextures          (uint32 n, uint32 *textures);                                                                                                                       

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetActiveAttrib      (uint32 program, uint32 index, uint32 bufSize, sint32 *length, sint32 *size, GLenum *type, char *name);                                            

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetActiveUniform     (uint32 program, uint32 index, uint32 bufSize, sint32 *length, sint32 *size, GLenum *type, char *name);                                            

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetAttachedShaders   (uint32 program, uint32 maxCount, sint32 *count, uint32 *shaders);                                                                                  

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern sint32    emu_glGetAttribLocation    (uint32 program, char *name);                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetBooleanv          (GLenum pname, GLboolean *data);                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetBufferParameteriv (GLenum target, GLenum pname, sint32 *parms);

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLenum    emu_glGetError             ();                                                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetFloatv            (GLenum pname, float *data);                                                                                                                       

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetFramebufferAttachmentParameteriv (GLenum target, GLenum attachment, GLenum pname, sint32 *parms);                                                                         

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetIntegerv          (GLenum pname, sint32 *data);                                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetProgramiv         (uint32 program, GLenum pname, sint32 *parms);                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetProgramInfoLog    (uint32 program, uint32 bufSize, uint32 *length, char *infoLog);                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetRenderbufferParameteriv   (GLenum target, GLenum pname, sint32 *parms);                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetShaderiv          (uint32 shader, GLenum pname, sint32 *parms);                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetShaderInfoLog     (uint32 shader, uint32 bufSize, uint32 *length, char *infoLog);                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetShaderPrecisionFormat (GLenum shadertype, GLenum precisiontype, sint32 *range, sint32 *precision);                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetShaderSource      (uint32 shader, uint32 bufSize, uint32 *length, char *source);                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLubyte*  emu_glGetString            (GLenum name);                                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetTexParameterfv    (GLenum target, GLenum pname, float *parms);                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetTexParameteriv    (GLenum target, GLenum pname, sint32 *parms);                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetUniformfv         (uint32 program, sint32 location, float *parms);                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetUniformiv         (uint32 program, sint32 location, sint32 *parms);                                                                                                  

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern sint32    emu_glGetUniformLocation   (uint32 program, char *name);                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetVertexAttribfv     (uint32 index, GLenum pname, float *parms);                                                                                                       

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetVertexAttribiv     (uint32 index, GLenum pname, sint32 *parms);                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glGetVertexAttribPointerv  (uint32 index, GLenum pname, void **pointer);                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glHint                  (GLenum target, GLenum mode);                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLboolean emu_glIsBuffer              (uint32 buffer);                                                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLboolean emu_glIsEnabled             (GLenum cap);                                                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLboolean emu_glIsFramebuffer        (uint32 framebuffer);                                                                                                                               

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLboolean emu_glIsProgram            (uint32 program);                                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLboolean emu_glIsRenderbuffer       (uint32 renderbuffer);                                                                                                                              

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLboolean emu_glIsShader             (uint32 shader);                                                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern GLboolean emu_glIsTexture            (uint32 texture);                                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glLineWidth            (float width);                                                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glLinkProgram          (uint32 program);                                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glPixelStorei          (GLenum pname, sint32 param);                                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glPolygonOffset        (float factor, float units);                                                                                                                        

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glReadPixels           (sint32 x, sint32 y, uint32 width, uint32 height, GLenum format, GLenum type, void *pixels);                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glReleaseShaderCompiler();                                                                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glRenderbufferStorage  (GLenum target, GLenum internalformat, uint32 width, uint32 height);                                                                              

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glSampleCoverage       (float value, GLboolean invert);                                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glScissor              (sint32 x, sint32 y, uint32 width, uint32 height);                                                                                                  

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glShaderBinary         (uint32 count, uint32 *shaders, GLenum binaryformat, void *binary, uint32 length);                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glShaderSource         (uint32 shader, uint32 count, char **str, sint32 *length);                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glStencilFunc          (GLenum func, sint32 ref_, uint32 mask);                                                                                                            

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glStencilFuncSeparate  (GLenum face, GLenum func, sint32 ref_, uint32 mask);                                                                                              

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glStencilMask          (uint32 mask);                                                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glStencilMaskSeparate  (GLenum face, uint32 mask);                                                                                                                        

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glStencilOp            (GLenum fail, GLenum zfail, GLenum zpass);                                                                                                       

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glStencilOpSeparate    (GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass);                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glTexImage2D           (GLenum target, sint32 level, sint32 internalformat, uint32 width, uint32 height, sint32 border, GLenum format, GLenum type, void *pixels);

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glTexParameterf        (GLenum target, GLenum pname, float param);                                                                                                       

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glTexParameterfv       (GLenum target, GLenum pname, float *parms);                                                                                               

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glTexParameteri        (GLenum target, GLenum pname, sint32 param);                                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glTexParameteriv       (GLenum target, GLenum pname, sint32 *parms);                                                                                              

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glTexSubImage2D        (GLenum target, sint32 level, sint32 xoffset, sint32 yoffset, uint32 width, uint32 height, GLenum format, GLenum type, void *pixels);      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform1f            (sint32 location, float v0);                                                                                                                        

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform1fv           (sint32 location, uint32 count, float *value);                                                                                                

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform1i            (sint32 location, sint32 v0);                                                                                                                       

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform1iv           (sint32 location, uint32 count, sint32 *value);                                                                                               

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform2f            (sint32 location, float v0, float v1);                                                                                                              

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform2fv           (sint32 location, uint32 count, float *value);                                                                                                

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform2i            (sint32 location, sint32 v0, sint32 v1);                                                                                                            

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform2iv           (sint32 location, uint32 count, sint32 *value);                                                                                               

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform3f            (sint32 location, float v0, float v1, float v2);                                                                                                    

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform3fv           (sint32 location, uint32 count, float *value);                                                                                                

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform3i            (sint32 location, sint32 v0, sint32 v1, sint32 v2);                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform3iv           (sint32 location, uint32 count, sint32 *value);                                                                                               

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform4f            (sint32 location, float v0, float v1, float v2, float v3);                                                                                          

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform4fv           (sint32 location, uint32 count, float *value);                                                                                                

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform4i            (sint32 location, sint32 v0, sint32 v1, sint32 v2, sint32 v3);                                                                                      

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniform4iv           (sint32 location, uint32 count, sint32 *value);                                                                                               

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniformMatrix2fv     (sint32 location, uint32 count, GLboolean transpose, float *value);                                                                           

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniformMatrix3fv     (sint32 location, uint32 count, GLboolean transpose, float *value);                                                                           

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUniformMatrix4fv     (sint32 location, uint32 count, GLboolean transpose, float *value);                                                                           

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glUseProgram           (uint32 program);                                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glValidateProgram      (uint32 program);                                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glVertexAttrib1f       (uint32 index, float x);                                                                                                                            

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glVertexAttrib1fv      (uint32 index, float *v);                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glVertexAttrib2f       (uint32 index, float x, float y);                                                                                                                   

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glVertexAttrib2fv      (uint32 index, float *v);                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glVertexAttrib3f       (uint32 index, float x, float y, float z);                                                                                                          

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glVertexAttrib3fv      (uint32 index, float *v);                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glVertexAttrib4f       (uint32 index, float x, float y, float z, float w);                                                                                                 

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glVertexAttrib4fv      (uint32 index, float *v);                                                                                                                     

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glVertexAttribPointer      (uint32 index, sint32 size, GLenum type, GLboolean normalized, uint32 stride, void *pointer);                                                

        [DllImport(DllName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern void      emu_glViewport         (sint32 x, sint32 y, uint32 width, uint32 height);                                                                                                  
    }
}
