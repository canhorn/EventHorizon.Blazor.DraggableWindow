namespace EventHorizon.Blazor.DraggableWindow.Shared.Components
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.JSInterop;

    public class DraggableWindowModel
         : ComponentBase
    {

        [Parameter]
        public bool IsDraggable { get; set; } = true;
        [Parameter]
        public RenderFragment Header { get; set; } = null!;
        [Parameter]
        public RenderFragment Body { get; set; } = null!;

        [Inject]
        public IJSRuntime JSRuntime { get; set; } = null!;

        public ElementReference DraggableWindow;

        private double pos1 = 0;
        private double pos2 = 0;
        private double pos3 = 0;
        private double pos4 = 0;

        public double Top { get; set; }
        public double Left { get; set; }

        public bool isDragging;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        public void HandleDragMouseDown(MouseEventArgs args)
        {
            System.Console.WriteLine("Starting Drag...");
            pos3 = args.ClientX;
            pos4 = args.ClientY;

            isDragging = true;
        }

        public void HandleElementDrag(MouseEventArgs args)
        {
            if (!isDragging)
            {
                return;
            }
            System.Console.WriteLine("Moving...");
            pos1 = pos3 - args.ClientX;
            pos2 = pos4 - args.ClientY;
            pos3 = args.ClientX;
            pos4 = args.ClientY;

            Top -= pos2;
            Left -= pos1;
        }

        public void HandleStopDragging(MouseEventArgs _)
        {
            isDragging = false;
        }
    }
}