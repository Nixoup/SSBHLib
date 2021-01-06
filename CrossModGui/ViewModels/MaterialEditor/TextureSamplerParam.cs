﻿using SSBHLib.Formats.Materials;
using static SSBHLib.Formats.Materials.MatlAttribute;

namespace CrossModGui.ViewModels.MaterialEditor
{
    public class TextureSamplerParam : ViewModelBase
    {
        public string ParamId { get; }
        public string SamplerParamId { get; }

        public string Value 
        {
            get => ((MatlString)textureAttribute.DataObject).Text;
            set
            {
                ((MatlString)textureAttribute.DataObject).Text = value;
                OnPropertyChanged();
            }
        }

        public MatlWrapMode WrapS
        {
            get => ((MatlSampler)samplerAttribute.DataObject).WrapS;
            set
            {
                ((MatlSampler)samplerAttribute.DataObject).WrapS = value;
                OnPropertyChanged();
            }
        }

        public MatlWrapMode WrapT
        {
            get => ((MatlSampler)samplerAttribute.DataObject).WrapT;
            set
            {
                ((MatlSampler)samplerAttribute.DataObject).WrapT = value;
                OnPropertyChanged();
            }
        }

        public MatlWrapMode WrapR
        {
            get => ((MatlSampler)samplerAttribute.DataObject).WrapR;
            set
            {
                ((MatlSampler)samplerAttribute.DataObject).WrapR = value;
                OnPropertyChanged();
            }
        }

        public MatlMinFilter MinFilter
        {
            get => ((MatlSampler)samplerAttribute.DataObject).MinFilter;
            set
            {
                ((MatlSampler)samplerAttribute.DataObject).MinFilter = value;
                OnPropertyChanged();
            }
        }

        public MatlMagFilter MagFilter
        {
            get => ((MatlSampler)samplerAttribute.DataObject).MagFilter;
            set
            {
                ((MatlSampler)samplerAttribute.DataObject).MagFilter = value;
                OnPropertyChanged();
            }
        }

        public FilteringType TextureFilteringType
        {
            get => ((MatlSampler)samplerAttribute.DataObject).TextureFilteringType;
            set
            {
                ((MatlSampler)samplerAttribute.DataObject).TextureFilteringType = value;
                OnPropertyChanged();
            }
        }

        public string TextureSamplerText => $"{ParamId} / {SamplerParamId}";

        public float LodBias
        {
            get => ((MatlSampler)samplerAttribute.DataObject).LodBias;
            set
            {
                ((MatlSampler)samplerAttribute.DataObject).LodBias = value;
                OnPropertyChanged();
            }
        }

        public int MaxAnisotropy
        {
            get => ((MatlSampler)samplerAttribute.DataObject).MaxAnisotropy;
            set
            {
                ((MatlSampler)samplerAttribute.DataObject).MaxAnisotropy = value;
                OnPropertyChanged();
            }
        }

        private readonly MatlAttribute textureAttribute;
        private readonly MatlAttribute samplerAttribute;

        public TextureSamplerParam(MatlAttribute textureAttribute, MatlAttribute samplerAttribute)
        {
            this.textureAttribute = textureAttribute;
            this.samplerAttribute = samplerAttribute;

            ParamId = textureAttribute.ParamId.ToString();
            SamplerParamId = samplerAttribute.ParamId.ToString();
            Value = (textureAttribute.DataObject as MatlString)?.Text ?? "";
        }
    }
}