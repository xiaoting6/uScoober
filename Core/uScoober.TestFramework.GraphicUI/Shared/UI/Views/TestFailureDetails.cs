﻿using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using TinyFonts;
using uScoober.TestFramework.Core;

namespace uScoober.TestFramework.UI.Views
{
    internal class TestFailureDetails : ContentControl
    {
        internal TestFailureDetails(TestCaseResult testCaseResult, int displayId) {
            Child = new StackPanel(Orientation.Horizontal) {
                Children = {
                    new Control {
                        Width = 4
                    },
                    new Microsoft.SPOT.Presentation.Controls.Text(Fonts.Small, displayId + " ") {
                        ForeColor = Colors.Black
                    },
                    new StackPanel(Orientation.Vertical) {
                        Width = SystemMetrics.ScreenWidth,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Children = {
                            new Microsoft.SPOT.Presentation.Controls.Text(Fonts.Small, testCaseResult.Name) {
                                ForeColor = Colors.Red,
                                TextWrap = true
                            },
                            new Microsoft.SPOT.Presentation.Controls.Text(Fonts.Small, testCaseResult.ExceptionMessage) {
                                ForeColor = Colors.Black,
                                TextWrap = true
                            },
                            new Control {
                                Height = 3
                            }
                        }
                    }
                }
            };
        }
    }
}